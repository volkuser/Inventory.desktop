using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("InspectedUnit")]
public class InspectedUnit
{
    [Key] [Column("IdInspectedUnit")]
    public int IdInspectedUnit { get; set; }
    
    [Column("InventoryId")]
    public int InventoryId { get; set; }
    [ForeignKey("Inventory")]
    public Inventory? Inventory { get; set; }
    
    [Column("EquipmentUnitId")]
    public int EquipmentUnitId { get; set; }
    [ForeignKey("EquipmentUnitId")]
    public EquipmentUnit? EquipmentUnit { get; set; }
}