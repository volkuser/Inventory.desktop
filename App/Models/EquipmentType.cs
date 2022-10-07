using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("EquipmentType")]
public class EquipmentType
{
    [Key] [Column("IdEquipmentType")]
    public int IdEquipmentType { get; set; }
    [Column("Name")]
    public string? Name { get; set; }
}