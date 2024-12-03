
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD_MVVM2_Q42024.Models;
using CRUD_MVVM2_Q42024.Services;
using CRUD_MVVM2_Q42024.Views;
using System.Collections.ObjectModel;

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
    }
}
