using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Input;
using ReactiveUI;

namespace App.ViewModels;

public class MainWindowViewModel : ReactiveObject, IScreen, IPageNavigation
{
    [DataMember] public RoutingState Router { get; set; } = new();
    
    // commands
    private ICommand OnClickBtnBack { get; set; }
    
    // properties of element on view
    private bool VisibleBtnBack { get; set; }
    private List<bool> VisibilityBtnBackHistory { get; set; } = new();

    public MainWindowViewModel()
    {
        Singleton.GetInstance();
        OpnAuthorizationPage();

        OnClickBtnBack = ReactiveCommand.Create(Back);
    }

    public void OpnAuthorizationPage()
    {
        //var viewModel = new
        AdditionForBtnBackViewHistory(false);
    }
    
    // for return to back
    
    public void Back()
    {
        Router.NavigateBack.Execute();
        VisibilityBtnBackHistory.RemoveAt(VisibilityBtnBackHistory.Count - 1);
        SetVisibleBtnBack(VisibilityBtnBackHistory[^1]);
    }
    
    private void AdditionForBtnBackViewHistory(bool visibleBtnBack)
    {
        VisibilityBtnBackHistory.Add(visibleBtnBack);
        SetVisibleBtnBack(visibleBtnBack);
    }
    
    private void SetVisibleBtnBack(bool visible) => VisibleBtnBack = visible;
}