using MyTaskMaui.ViewModels;

namespace MyTaskMaui.Views;

public partial class TaskDetailPage : ContentPage
{
	public TaskDetailPage(TaskDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}