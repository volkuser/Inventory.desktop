using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("Role")]
public class Role
{
    [Key] [Column("IdRole")]
    public int IdRole { get; set; }
    [Column("Name")]
    public string? Name { get; set; }
}