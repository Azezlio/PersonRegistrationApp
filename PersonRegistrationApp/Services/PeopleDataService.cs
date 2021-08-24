using PersonRegistrationShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonRegistrationApp.Services
{
    public class PeopleDataService : IPeopleDataService
    {
        private readonly HttpClient _httpClient;

        public PeopleDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Person> AddPerson(Person person)
        {
            var personJson =
                new StringContent(JsonSerializer.Serialize(person), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/person", personJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Person>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdatePerson(Person person)
        {
            var personJson =
                new StringContent(JsonSerializer.Serialize(person), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/person", personJson);
        }

        public async Task DeletePerson(int personId)
        {
            await _httpClient.DeleteAsync($"api/person/{personId}");
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Person>>
                    (await _httpClient.GetStreamAsync($"api/person"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Person> GetPersonDetails(int personId)
        {
            return await JsonSerializer.DeserializeAsync<Person>
                (await _httpClient.GetStreamAsync($"api/person/{personId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

    }
}
