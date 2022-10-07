using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("Status")]
public class Status
{
    [Key] [Column("IdStatus")]
    public int IdStatus { get; set; }
    [Column("Name")]
    public string? Name { get; set; }
}