using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

public class Location
{
    [Key] [Column("IdLocation")]
    public int IdLocation { get; set; }
    [Column("Number")]
    public string? Number { get; set; }
    [Column("Description")]
    public string? Description { get; set; }
    [Column("TrainingCenterId")]
    public int TrainingCenterId { get; set; }
    [ForeignKey("TrainingCenterId")]
    public TrainingCenter? TrainingCenter { get; set; }
}