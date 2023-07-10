using MyTaskMaui.Views;

namespace MyTaskMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(TaskDetailPage), typeof(TaskDetailPage));
	}
}
