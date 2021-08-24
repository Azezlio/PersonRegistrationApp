using Microsoft.AspNetCore.Components;
using PersonRegistrationApp.Services;
using PersonRegistrationShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonRegistrationApp.Pages
{
    public partial class PersonOverview
    {


		public IEnumerable<Person> People { get; set; }

        [Inject]
        public IPeopleDataService PersonDataService { get; set; }


        protected async override Task OnInitializedAsync()
        {

            People = (await PersonDataService.GetAllPeople()).ToList();


        }

       
        public async void AddPersonDialog_OnDialogClose()
        {
            People = (await PersonDataService.GetAllPeople()).ToList();
            StateHasChanged();
        }


    }
}
