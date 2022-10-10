using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("Inventory")]
public class Inventory
{
    [Key] [Column("IdInventory")]
    public int IdInventory { get; set; }
    [Column("EventDate")]
    public DateTime EventDate { get; set; }
    [NotMapped]
    public DateTimeOffset OffsetEventDate => new DateTimeOffset(EventDate);
    
    [Column("CommissionId")]
    public int CommissionId { get; set; }
    [ForeignKey("CommissionId")]
    public Commission? Commission { get; set; }
}