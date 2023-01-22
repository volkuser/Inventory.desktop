using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("Equipment")]
public class Equipment
{
    [Key] [Column("IdEquipment")]
    public int IdEquipment { get; set; }
    [Column("Model")]
    public string? Model { get; set; }
    
    [Column("EquipmentTypeId")]
    public int EquipmentTypeId { get; set; }
    public EquipmentType? EquipmentType { get; set; }
}