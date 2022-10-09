using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.Administrator;

public class TrainingCenterControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "trainingCenter";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }

    public TrainingCenterControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
    }
}    