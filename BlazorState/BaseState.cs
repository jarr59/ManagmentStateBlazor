using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq.Expressions;

namespace BlazorState
{
    /// <summary>
    /// Provides a mechanism to implement state management patterns such as Flux, Redux, and Observable.
    /// This class is designed to facilitate state management in your Blazor application by leveraging
    /// the CommunityToolkit.Mvvm library for property change notifications.
    /// 
    /// The <see cref="BaseState{T}"/> class inherits from <see cref="ObservableObject"/>, which implements
    /// the <see cref="INotifyPropertyChanged"/> interface. This allows derived state classes to notify
    /// the UI of property changes, enabling reactive and efficient state updates.
    /// 
    /// Example usage:
    /// <code>
    /// public class CustomerState : BaseState&lt;CustomerState&gt;
    /// {
    ///     [ObservableProperty]
    ///     private string firstName;
    /// 
    ///     [ObservableProperty]
    ///     private string lastName;
    /// }
    /// 
    /// var customerState = new CustomerState();
    /// customerState.SubscribeToPropertyChange(state => state.FirstName, () => StateHasChanged -> Is method from blazor component);
    /// </code>
    /// </summary>
    /// <typeparam name="T">The type of the derived state class.</typeparam>
    public class BaseState<T> : ObservableObject
    {
        /// <summary>
        /// Subscribes to property changes for a specified property.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="propertySelector">An expression that selects the property to observe.</param>
        /// <param name="callback">The callback to invoke when the property changes.</param>
        /// <exception cref="ArgumentException">Thrown when the property selector expression is not valid.</exception>
        public void SubscribeToPropertyChange<TProperty>(Expression<Func<T, TProperty>> propertySelector, Action callback)
        {
            if (propertySelector.Body is MemberExpression memberExpression)
            {
                var propertyName = memberExpression.Member.Name;

                PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == propertyName)
                        callback();
                };
            }
            else
            {
                throw new ArgumentException("The property selector expression is not valid.");
            }
        }
    }
}
