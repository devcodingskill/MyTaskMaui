using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskMaui.ViewModels
{
    [QueryProperty("Text","parameter")]
    public partial class TaskDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        string text;

    }
}
