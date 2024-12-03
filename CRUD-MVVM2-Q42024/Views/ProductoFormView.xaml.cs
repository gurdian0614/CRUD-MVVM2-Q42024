using CRUD_MVVM2_Q42024.Models;
using CRUD_MVVM2_Q42024.ViewModels;

namespace CRUD_MVVM2_Q42024.Views;

public partial class ProductoFormView : ContentPage
{
	ProductoFormViewModel viewModel = new ProductoFormViewModel();
	public ProductoFormView()
	{
		InitializeComponent();
		viewModel = new ProductoFormViewModel();
		BindingContext = viewModel;
	}

	public ProductoFormView(Producto producto)
	{
        InitializeComponent();
        viewModel = new ProductoFormViewModel(producto);
        BindingContext = viewModel;
    }
}