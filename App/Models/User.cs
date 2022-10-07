using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("User")]
public class User
{
    [Key] [Column("IdUser")]
    public int IdUser { get; set; }
    [Column("Login")]
    public string? Login { get; set; }
    [Column("Password")]
    public string? Password { get; set; }
    
    [Column("RoleId")]
    public int RoleId { get; set; }
    [ForeignKey("RoleId")]
    public Role? Role { get; set; }
    
    [Column("EmployeeId")]
    public int EmployeeId { get; set; }
    [ForeignKey("EmployerId")]
    public Employee? Employee { get; set; }
}