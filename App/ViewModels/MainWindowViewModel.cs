using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Input;
using App.Models;
using App.ViewModels.Administrator;
using App.ViewModels.CommissionMember;
using App.ViewModels.CommissionPreparer;
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
        var viewModel = new AuthorizationPageViewModel(this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(false);
    }
    
    // login as an administrator
    
    public void OpnAdministratorMenuPage()
    {
        var viewModel = new AdministratorMenuPageViewModel(this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(true);
    }
    
    public void OpnEmployeeControlPage()
    {
        var viewModel = new EmployeeControlPageViewModel(this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(true);
    }
    
    public void OpnTrainingCenterControlPage()
    {
        var viewModel = new TrainingCenterControlPageViewModel(this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(true);
    }

    // login as an commission member
    
    public void OpnCommissionMemberMenuPage(User currentUser)
    {
        var viewModel = new CommissionMemberMenuPageViewModel(currentUser, this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(true);
    }
    
    public void OpnEquipmentControlPage()
    {
        var viewModel = new EquipmentControlPageViewModel(this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(true);
    }
    
    public void OpnEquipmentTypeControlPage()
    {
        var viewModel = new EquipmentTypeControlViewModel(this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(true);
    }
    
    public void OpnEquipmentUnitControlPage(User currentUser)
    {
        var viewModel = new EquipmentUnitControlPageViewModel(currentUser, this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(true);
    }
    
    // login as commission preparer
    
    public void OpnCommissionPreparerMenuPage()
    {
        var viewModel = new CommissionPreparerMenuPageViewModel(this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(true);
    }
    
    public void OpnCommissionMemberControlPage()
    {
        var viewModel = new CommissionMemberControlPageViewModel(this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(true);
    }
    
    public void OpnCommissionControlPage()
    {
        var viewModel = new CommissionControlPageViewModel(this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(true);
    }
    
    public void OpnInspectedUnitControlPage()
    {
        var viewModel = new InspectedUnitControlPageViewModel(this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(true);
    }
    
    public void OpnInventoryControlPage()
    {
        var viewModel = new InventoryControlPageViewModel(this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(true);
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