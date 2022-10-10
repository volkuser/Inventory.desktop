using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionMember;

public class AudienceControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "audienceControl";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ObservableCollection<Audience> Audiences { get; set; }
    
    private List<TrainingCenter> TrainingCenters { get; set; }

    private Audience _selectedValue;
    public Audience SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;
            
            Number = value.Number!;
            TrainingCenter = value.TrainingCenter!;
        }
    }
    
    private string Number { get; set; }
    private TrainingCenter TrainingCenter { get; set; }
    
    private ICommand OnClickBtnInsert { get; set; }
    private ICommand OnClickBtnUpdate { get; set; }
    private ICommand OnClickBtnDelete { get; set; }

    public AudienceControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        Audiences = new ObservableCollection<Audience>(Db.Audiences!);

        TrainingCenters = new List<TrainingCenter>(Db.TrainingCenters!);

        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert()
    {
        Audience inserting = new Audience()
        {
            Number = Number,
            TrainingCenter = TrainingCenter
        };
        Audiences.Add(inserting);
        Db.Audiences!.Add(inserting);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Update()
    {
        SelectedValue.Number = Number;
        SelectedValue.TrainingCenter = TrainingCenter;
        Db.Audiences!.Update(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Delete()
    {
        Audiences.Remove(SelectedValue);
        Db.Audiences!.Remove(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}    