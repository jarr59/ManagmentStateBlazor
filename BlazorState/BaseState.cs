using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq.Expressions;

namespace BlazorState
{
    public class BaseState<T> : ObservableObject
    {
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
