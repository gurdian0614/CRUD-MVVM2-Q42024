
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD_MVVM2_Q42024.Models;
using CRUD_MVVM2_Q42024.Services;
using CRUD_MVVM2_Q42024.Views;

namespace CRUD_MVVM2_Q42024.ViewModels
{
    public partial class ProductoFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string codigo;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private int cantidad;

        [ObservableProperty]
        private double precio;

        private readonly ProductoService service;

        public ProductoFormViewModel()
        {
            service = new ProductoService();
        }

        public ProductoFormViewModel(Producto producto)
        {
            service = new ProductoService();
            Id = producto.Id;
            Codigo = producto.Codigo;
            Nombre = producto.Nombre;
            Cantidad = producto.Cantidad;
            Precio = producto.Precio;
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Producto producto = new Producto();
                producto.Id = Id;
                producto.Codigo = Codigo;
                producto.Nombre = Nombre;
                producto.Cantidad = Cantidad;
                producto.Precio = Precio;

                if (Validar(producto))
                {
                    if (Id == 0)
                    {
                        service.Insert(producto);
                    } else
                    {
                        service.Update(producto);
                    }
                    // Regresa a la pantalla principal
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        private bool Validar(Producto producto)
        {
            if (producto.Codigo == null || producto.Codigo == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el código del producto");
                return false;
            } else if (producto.Nombre == null || producto.Nombre == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el nombre del producto");
                return false;
            } else
            {
                return true;
            }
        }
    }
}
