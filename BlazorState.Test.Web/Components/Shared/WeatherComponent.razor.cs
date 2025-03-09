using BlazorState.Test.Web.Store.States;
using Microsoft.AspNetCore.Components;

namespace BlazorState.Test.Web.Components.Shared
{
    public partial class WeatherComponent
    {
        [Inject]
        public required CustomerState CustomerState { get; set; }

        protected override void OnInitialized()
        {
            CustomerState.FirstName = "John";

            CustomerState.LastName = "Dereck";

            base.OnInitialized();
        }
    }
}
