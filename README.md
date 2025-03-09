# Biblioteca BlazorState

BlazorState es una biblioteca de gestión de estado diseñada para facilitar la implementación de patrones de gestión de estado como Flux, Redux y Observable en aplicaciones Blazor. Al aprovechar la biblioteca `CommunityToolkit.Mvvm`, BlazorState proporciona un mecanismo robusto para manejar cambios de estado y asegurar que tu interfaz de usuario se mantenga reactiva y eficiente.

## Características

- **Gestión de Estado**: Implementa patrones de gestión de estado como Flux, Redux y Observable.
- **Notificaciones de Cambio de Propiedad**: Utiliza la biblioteca `CommunityToolkit.Mvvm` para notificar a la interfaz de usuario sobre cambios de propiedad.
- **Actualizaciones Reactivas de la UI**: Asegura que tu interfaz de usuario se actualice de manera eficiente en respuesta a cambios de estado.


### Uso

1. **Define tu Clase de Estado**

   Crea una clase de estado que herede de `BaseState<T>`. Utiliza el atributo `[ObservableProperty]` para definir propiedades que deben notificar a la interfaz de usuario sobre cambios.

    ```
    using CommunityToolkit.Mvvm.ComponentModel;
    
    namespace BlazorState.Test.Web.Store.States 
    { 
    
        public partial class CustomerState : BaseState<CustomerState> 
        { 
            [ObservableProperty]
            private string firstName;
            
            [ObservableProperty]
            private string lastName;
            
        }
    }
    ```

2. **Registra tu state**

    Para que el estado estado persista dentro de tu aplicacion debes registrar en IoC
    
    ```
    builder.Services.AddScoped<CustomerState>();
    ```


3. **Suscríbete a Cambios de Propiedad**

   En tus componentes Blazor, suscríbete a cambios de propiedad utilizando el método `SubscribeToPropertyChange`. Esto asegura que tu componente se actualice cuando el estado cambie.
   
    ```
    @page "/" 
    @inject CustomerState CustomerState
    
    <h3>Cliente</h3> <p>Nombre: @CustomerState.FirstName</p>
    
    <p>Apellido: @CustomerState.LastName</p>
    
    @code { 
    
        protected override void OnInitialized() 
        { 
            CustomerState.SubscribeToPropertyChange(state => state.FirstName, StateHasChanged);
            
            CustomerState.SubscribeToPropertyChange(state => state.LastName, StateHasChanged); 
            
            base.OnInitialized(); 
        } 
    }
    ```

