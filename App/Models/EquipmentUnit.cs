using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("EquipmentUnit")]
public class EquipmentUnit
{
    [Key] [Column("IdEquipmentUnit")]
    public int IdEquipmentUnit { get; set; }
    [Column("SerialNumber")]
    public string? SerialNumber { get; set; }
    [Column("InventoryNumber")]
    public string? InventoryNumber { get; set; }
    
    [Column("AvailabilityId")]
    public int AvailabilityId { get; set; }
    [ForeignKey("AvailabilityId")]
    public Availability? Availability { get; set; }
    
    [Column("TrainingCenterId")]
    public int TrainingCenterId { get; set; }
    [ForeignKey("TrainingCenterId")]
    public TrainingCenter? TrainingCenter { get; set; }
    
    [Column("StateId")]
    public int StateId { get; set; }
    [ForeignKey("StateId")]
    public State? State { get; set; }
    
    [Column("EquipmentId")]
    public int EquipmentId { get; set; }
    [ForeignKey("EquipmentId")]
    public Equipment? Equipment { get; set; }
}