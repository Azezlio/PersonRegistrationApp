using Microsoft.AspNetCore.Components;
using PersonRegistrationApp.Services;
using PersonRegistrationShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonRegistrationApp.Pages
{
    public partial class PersonDetail
    {
        [Parameter]
        public string PersonId { get; set; }

        public Person Person { get; set; } = new Person();


        [Inject]
        public IPeopleDataService PeopleDataService { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Person = await PeopleDataService.GetPersonDetails(int.Parse(PersonId));

        }
    }
}
