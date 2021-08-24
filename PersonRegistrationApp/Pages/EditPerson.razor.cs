using Microsoft.AspNetCore.Components;
using PersonRegistrationApp.Services;
using PersonRegistrationShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonRegistrationApp.Pages
{
    public partial class EditPerson
    {
        [Inject]
        public IPeopleDataService PeopleDataService { get; set; }

        [Parameter]
        public string PersonId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        public Person Person { get; set; } = new Person();


        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            int.TryParse(PersonId, out var personId);

            if (personId == 0) //new person is being created
            {
                //add some defaults
                Person = new Person { BirthDate = DateTime.Now };
            }
            else
            {
                Person = await PeopleDataService.GetPersonDetails(int.Parse(PersonId));
            }
            
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Person.PersonId == 0) //new
            {
                var addedPerson = await PeopleDataService.AddPerson(Person);
                if (addedPerson != null)
                {
                    StatusClass = "alert-success";
                    Message = "New person added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new person. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await PeopleDataService.UpdatePerson(Person);
                StatusClass = "alert-success";
                Message = "Person updated successfully.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeletePerson()
        {
            await PeopleDataService.DeletePerson(Person.PersonId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/personoverview");
        }
    }
}

