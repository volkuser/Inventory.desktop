using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("CommissionMember")]
public class CommissionMember
{
    [Key] [Column("IdCommissionMember")]
    public int IdCommissionMember { get; set; }
    
    [Column("CommissionId")]
    public int CommissionId { get; set; }
    [ForeignKey("CommissionId")]
    public Commission? Commission { get; set; }
    
    [Column("EmployeeId")]
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee? Employee { get; set; }
}