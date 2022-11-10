using System;
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
    [Column("LocationId")]
    public int LocationId { get; set; }
    [ForeignKey("LocationId")]
    public Location? Location { get; set; }
    [Column("StateId")]
    public int StateId { get; set; }
    [ForeignKey("StateId")]
    public State? State { get; set; }
    [Column("EquipmentId")]
    public int EquipmentId { get; set; }
    [ForeignKey("EquipmentId")]
    public Equipment? Equipment { get; set; }
    [Column("ResponsiblePersonId")]
    public int ResponsiblePersonId { get; set; }
    [ForeignKey("ResponsiblePersonId")]
    public Employee? ResponsiblePerson { get; set; }
    [Column("Price")]
    public decimal Price { get; set; }
    [Column("InstallationDate")]
    public DateTime InstallationDate { get; set; }
    [Column("DecommissioningDate")]
    public DateTime DecommissioningDate { get; set; }
    [Column("ReasonsForDecommissioning")]
    public string? ReasonsForDecommissioning { get; set; }

    [NotMapped]
    public DateTimeOffset OffsetInstallationDate => new DateTimeOffset(InstallationDate);
    [NotMapped]
    public DateTimeOffset OffsetDecommissioningDate => new DateTimeOffset(DecommissioningDate);
}