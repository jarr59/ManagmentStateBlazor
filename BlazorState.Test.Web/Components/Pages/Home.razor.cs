using BlazorState.Test.Web.Store.States;
using Microsoft.AspNetCore.Components;

namespace BlazorState.Test.Web.Components.Pages
{
    public partial class Home
    {
        [Inject]
        public required CustomerState CustomerState { get; set; }

        /// <summary>
        /// Indica si debe mostrar el componente de clima
        /// </summary>
        bool ShowWeaterComponent = false;
        protected override void OnInitialized()
        {
            CustomerState.SubscribeToPropertyChange(e => e.FirstName, StateHasChanged);

            base.OnInitialized();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.Delay(20);
                
                ShowWeaterComponent = true;

                StateHasChanged();
            }

            await base.OnAfterRenderAsync(firstRender);
        }

    }
}
