using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.Administrator;

public class TrainingCenterControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "trainingCenter";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ObservableCollection<TrainingCenter> TrainingCenters { get; set; }

    private TrainingCenter _selectedValue;
    public TrainingCenter SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;
            
            Address = value.Address;
        }
    }
    
    private string? Address { get; set; }
    
    private ICommand OnClickBtnInsert { get; set; }
    private ICommand OnClickBtnUpdate { get; set; }
    private ICommand OnClickBtnDelete { get; set; }

    public TrainingCenterControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        TrainingCenters = new ObservableCollection<TrainingCenter>(Db.TrainingCenters!);

        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert()
    {
        TrainingCenter inserting = new TrainingCenter()
        {
            Address = Address
        };
        TrainingCenters.Add(inserting);
        Db.TrainingCenters!.Add(inserting);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Update()
    {
        SelectedValue.Address = Address;
        Db.TrainingCenters!.Update(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        TrainingCenters.Clear();
        TrainingCenters = new ObservableCollection<TrainingCenter>(Db.TrainingCenters!);
    }

    private void Delete()
    {
        TrainingCenters.Remove(SelectedValue);
        Db.TrainingCenters!.Remove(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}    