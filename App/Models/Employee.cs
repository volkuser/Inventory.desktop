using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("Employee")]
public class Employee
{
    [Key] [Column("IdEmployee")] 
    public int IdEmployee { get; set; }
    [Column("LastName")]
    public string? LastName { get; set; }
    [Column("FirstName")]
    public string? FirstName { get; set; }
    [Column("Email")]
    public string? Email { get; set; }
}