using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("Availability")]
public class Availability
{
    [Key] [Column("IdAvailability")]
    public int IdAvailability { get; set; }
    [Column("Name")]
    public string? Name { get; set; }
}