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
    [Column("Patronymic")]
    public string? Patronymic { get; set; }
    [Column("DocumentPositionId")]
    public int DocumentPositionId { get; set; }
    [ForeignKey("DocumentPositionId")]
    public DocumentPosition? DocumentPosition { get; set; }
}