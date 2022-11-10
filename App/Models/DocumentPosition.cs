using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("DocumentPosition")]
public class DocumentPosition
{
    [Key] [Column("DocumentPosition")]
    public int IdDocumentPosition { get; set; }
    public string? Name { get; set; }
}