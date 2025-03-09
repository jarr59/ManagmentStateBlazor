# BlazorState Project

Este proyecto utiliza Blazor para crear una aplicación web con un patrón de gestión de estado. La clase base BaseState<T> proporciona un mecanismo para implementar patrones de gestión de estado como Flux, Redux y Observable. Esta clase facilita la gestión del estado en tu aplicación Blazor aprovechando la biblioteca CommunityToolkit.Mvvm para notificaciones de cambios de propiedades.

# BaseState<T>
La clase BaseState<T> implementa la interfaz INotifyPropertyChanged, lo que permite a las clases derivadas notificar a la interfaz de usuario sobre los cambios en las propiedades, habilitando actualizaciones de estado reactivas y eficientes.
Métodos y Propiedades

    •   NotifyPropertyChanged: Notifica a los oyentes cuando una propiedad cambia.
    •   SubscribeToAnyChange: Se suscribe a cualquier cambio de propiedad en el estado.
    •   SubscribeToPropertyChange: Se suscribe a los cambios de una propiedad específica.


### Ejemplo de Uso

1. **Implementación en CustomerState**

    La clase CustomerState hereda de BaseState<CustomerState> y define dos propiedades: FirstName y LastName.
    Estas propiedades notifican a la interfaz de usuario cuando cambian, utilizando el método
    NotifyPropertyChanged de la clase base.
    
    ```
        public class CustomerState : BaseState<CustomerState>
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
    ```
    
2. **Registra tu state**

    Para que el estado estado persista dentro de tu aplicacion debes registrar en IoC
    
    ```
    builder.Services.AddScoped<CustomerState>();
    ```
3. **Uso en un Componente Blazor**

    En este ejemplo, el componente CustomerForm utiliza CustomerState para enlazar y actualizar las propiedades
    firstName y lastName. Se suscribe a los cambios de estado para actualizar la interfaz de usuario cuando las
    propiedades de CustomerState cambian.
    
    ```
    @using BlazorState.Test.Web.Store.States
    @inject CustomerState CustomerState
    
    <label>Nombres</label>
    <input @bind-value="firstName">
    
    <label>Apellidos</label>
    <input @bind-value="lastName">
    
    <button @onclick="Save">Guardar</button>
    
    @code {
        string firstName = string.Empty;
        string lastName = string.Empty;
    
        protected override void OnInitialized()
        {
            firstName = CustomerState.FirstName;
            lastName = CustomerState.LastName;
    
            CustomerState.SubscribeToAnyChange(() =>
            {
                if (string.IsNullOrEmpty(CustomerState.FirstName) == false)
                {
                    firstName = CustomerState.FirstName;
                }
    
                if (string.IsNullOrEmpty(CustomerState.LastName) == false)
                {
                    lastName = CustomerState.LastName;
                }
                
                StateHasChanged();
            });
    
            base.OnInitialized();
        }
    
        void Save()
        {
            if (string.IsNullOrEmpty(firstName) == false)
            {
                CustomerState.FirstName = firstName;
            }
    
            if (string.IsNullOrEmpty(lastName) == false)
            {
                CustomerState.LastName = lastName;
            }
        }
    }

    ```
