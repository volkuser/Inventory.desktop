using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("EquipmentUnit")]
public class EquipmentUnit
{
    [Key] [Column("IdEquipmentUnit")]
    public int IdEquipmentUnit { get; set; }
    [Column("Series")]
    public int Series { get; set; }
    [Column("Number")]
    public string? Number { get; set; }
    [Column("IntroductionDate")]
    public DateTime IntroductionDate { get; set; }
    
    [Column("StatusId")]
    public int StatusId { get; set; }
    [ForeignKey("StatusId")]
    public Status? Status { get; set; }
    
    [Column("AudienceId")]
    public int AudienceId { get; set; }
    [ForeignKey("AudienceId")]
    public Audience? Audience { get; set; }
    
    [Column("StateId")]
    public int StateId { get; set; }
    [ForeignKey("StateId")]
    public State? State { get; set; }
    
    [Column("EquipmentId")]
    public int EquipmentId { get; set; }
    [ForeignKey("EquipmentId")]
    public Equipment? Equipment { get; set; }
}