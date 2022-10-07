using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("State")]
public class State
{
    [Key] [Column("IdState")]
    public int IdState { get; set; }
    [Column("Name")]
    public string? Name { get; set; }
}