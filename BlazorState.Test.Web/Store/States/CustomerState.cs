using CommunityToolkit.Mvvm.ComponentModel;

namespace BlazorState.Test.Web.Store.States
{
    public partial class CustomerState : BaseState<CustomerState>
    {
        /// <summary>
        /// Nombres
        /// </summary>
        [ObservableProperty]
        private string firstName = string.Empty;

        /// <summary>
        /// Apellidos
        /// </summary>
        [ObservableProperty]
        private string lastName = string.Empty;
    }
}
