using MyTaskMaui.ViewModels;

namespace MyTaskMaui.Views;

public partial class MyTaskPage : ContentPage
{
	public MyTaskPage(MyTaskViewModel viewModel)
	{
		InitializeComponent();
		BindingContext =viewModel;
	}
}