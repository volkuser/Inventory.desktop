using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

public class Unit
{
    [Key] [Column("IdUnit")]
    private int IdUnit { get; set; }
    [Column("OKEICode")]
    private int OKEICode { get; set; }
    [Column("Name")]
    private string? Name { get; set; }
}