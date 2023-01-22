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
    private TrainingCenter SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;
            
            if (value == null) return;
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
        try
        {
            Db.TrainingCenters!.Add(inserting);
            Db.SaveChanges();
            TrainingCenters.Add(inserting);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Update()
    {
        try
        {
            Db.TrainingCenters!.Update(SelectedValue);
            Db.SaveChanges();
            SelectedValue.Address = Address;
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        TrainingCenters.Clear();
        TrainingCenters = new ObservableCollection<TrainingCenter>(Db.TrainingCenters!);
    }

    private void Delete()
    {
        try
        {
            Db.TrainingCenters!.Remove(SelectedValue);
            Db.SaveChanges();
            TrainingCenters.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}    