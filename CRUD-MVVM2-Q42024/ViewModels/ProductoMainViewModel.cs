
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD_MVVM2_Q42024.Models;
using CRUD_MVVM2_Q42024.Services;
using CRUD_MVVM2_Q42024.Views;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace CRUD_MVVM2_Q42024.ViewModels
{
    public partial class ProductoMainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Producto> productoCollection = new ObservableCollection<Producto>();

        private readonly ProductoService service;

        public ProductoMainViewModel()
        {
            service = new ProductoService();
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        public void GetAll()
        {
            var getAll = service.GetAll();

            if (getAll.Count > 0)
            {
                ProductoCollection.Clear();
                foreach (var producto in getAll) {
                    ProductoCollection.Add(producto);
                }
            }
        }

        [RelayCommand]
        private async Task GoToProductoFormView()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new ProductoFormView());
        }

        [RelayCommand]
        private async Task GoToEditProductoFormView(Producto producto)
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new ProductoFormView(producto));
        }

        private async Task EliminarProducto(Producto producto)
        {
            try
            {
                bool respuesta = await App.Current!.MainPage.DisplayAlert("ELIMINAR PRODUCTO", "¿Desea eliminar el producto?", "Si", "No");

                if (respuesta)
                {
                    int del = service.Delete(producto);

                    if (del > 0)
                    {
                        Alerta("ELIMINAR PRODUCTO", "Producto eliminado correctamente");
                        ProductoCollection.Remove(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        [RelayCommand]
        private async Task SelectProducto(Producto producto)
        {
            try
            {
                const string ACTUALIZAR = "Actualizar";
                const string ELIMINAR = "Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR, ELIMINAR);

                if (res == ACTUALIZAR)
                {
                    await GoToEditProductoFormView(producto);
                }
                else if (res == ELIMINAR)
                {
                    await EliminarProducto(producto);
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }
    }
}
