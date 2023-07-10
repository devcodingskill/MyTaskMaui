using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyTaskMaui.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskMaui.ViewModels
{
    public partial class MyTaskViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<string> item;

        [ObservableProperty]
        string text;

        public MyTaskViewModel()
        {
            Item = new ObservableCollection<string>();
        }
        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

            Item.Add(Text);
            Text = string.Empty;
        }
        [RelayCommand]
        void Deleted(string item)
        {
            if (Item.Contains(item))
                Item.Remove(item);
        }
        [RelayCommand]
        async Task OpenTaskDetail(string item) 
        {
            await Shell.Current.GoToAsync($"{nameof(TaskDetailPage)}?parameter={item}");
        }
    }
}
