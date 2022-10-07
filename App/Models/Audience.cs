using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("Audience")]
public class Audience
{
    [Key] [Column("IdAudience")]
    public int IdAudience { get; set; }
    [Column("Number")] 
    public string? Number { get; set; }
    
    [Column("TrainingCenterId")]
    public int TrainingCenterId { get; set; }
    [ForeignKey("TrainingCenterId")]
    public TrainingCenter? TrainingCenter { get; set; }
}