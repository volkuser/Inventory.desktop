using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("TrainingCenter")]
public class TrainingCenter
{
    [Key] [Column("TrainingCenter")]
    public int IdTrainingCenter { get; set; }
    [Column("Address")]
    public string? Address { get; set; }
}