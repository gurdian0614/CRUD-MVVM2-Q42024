using CRUD_MVVM2_Q42024.ViewModels;

namespace CRUD_MVVM2_Q42024.Views;

public partial class ProductoMainView : ContentPage
{
	private ProductoMainViewModel viewModel;
	public ProductoMainView()
	{
		InitializeComponent();
		viewModel = new ProductoMainViewModel();
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetAll();
    }
}