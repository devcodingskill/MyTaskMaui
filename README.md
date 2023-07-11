# MyTaskMaui
Do to list application with .Net MAUI
## Link 
- Making the logo => https://www.canva.com/logos/
- Edit image to tranparent => https://www4.lunapic.com/
- 
### How to create mockup data for collectionView
```c
<CollectionView Grid.Row="2"
                        Grid.ColumnSpan="2">
            <CollectionView.ItemsSource>
                <x:Array Type="{x:Type x:String}">
                    <x:String>Apple</x:String>
                    <x:String>Orange</x:String>
                    <x:String>Bananas</x:String>
                    <x:String>Mango</x:String>
                </x:Array>
            </CollectionView.ItemsSource>
```
### Problem and Solution
Problem => RelativeSource in MAUI control not bound see the detail on the link 
Link https://stackoverflow.com/questions/73417068/relativesource-in-maui-control-not-bound
```c
                   //this not work not sure why when get the answer will add it

                        <SwipeView.RightItems>
                            <SwipeItem Text="Delete" BackgroundColor="Red"
                                Command="{Binding Source={RelativeSource AncestorType={x:Type viewmodel:MainViewModel}}, Path=DeleteCommand}"
                                CommandParameter="{Binding .}">
                            </SwipeItem>
                        </SwipeView.RightItems>

                  //work set up x:name= mypage user for referent to binding context 

                  <SwipeItem Text="Delete"
                                       BackgroundColor="Red"
                                       Command="{Binding BindingContext.DeletedCommand, Source={x:Reference mypage}}"
                                       CommandParameter="{Binding .}"/>

```
### Step add TaskDetailPage
- Create TaskDetailPage as xaml contentPage in view folder
- Register in the AppShell
```c
public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(TaskDetailPage), typeof(TaskDetailPage));
	}
}

```
- Create TaskDetailViewModel as C# class in ViewModel folder
- Register both in MauiProgram.cs 
```c
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<MyTaskViewModel>();
		builder.Services.AddSingleton<MyTaskPage>();

       //register TaskDetail
        builder.Services.AddSingleton<TaskDetailViewModel>();
        builder.Services.AddSingleton<TaskDetailPage>();

        return builder.Build();
	}
}
```
- Passing TaskDetailViewModel to TaskDetailPage as we register when TaskDetailPage is create the container will create TaskDetailViewModel
```c

public partial class TaskDetailPage : ContentPage
{
	public TaskDetailPage(TaskDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
```
- Set up binding to TaskDetailPage.xaml and set up data type
```c
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:viewmodel="clr-namespace:MyTaskMaui.ViewModels"
             x:DataType="viewmodel:TaskDetailViewModel"
             x:Class="MyTaskMaui.Views.TaskDetailPage"
             Title="TaskDetailPage">
```
- Binding data to the page
```c
    <VerticalStackLayout>
        <Label 
            Text="{Binding  Text}"
            VerticalOptions="Center" 
            HorizontalOptions="Center" />
    </VerticalStackLayout>
</ContentPage>
```
### Navigate and passing data between page


