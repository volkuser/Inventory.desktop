using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("Commission")]
public class Commission
{
    [Key] [Column("IdCommission")]
    public int IdCommission { get; set; }
    [Column("CommissionFormationDate")]
    public DateTime CommissionFormationDate { get; set; }
}