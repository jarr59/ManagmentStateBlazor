namespace BlazorState.Test.Web.Store.States
{
    public partial class CustomerState : BaseState<CustomerState>
    {
        private string firstName = string.Empty;

        private string lastName = string.Empty;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; NotifyPropertyChanged(); }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; NotifyPropertyChanged(); }
        }
    }
}
