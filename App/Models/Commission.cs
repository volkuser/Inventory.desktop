using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("Commission")]
public class Commission
{
    [Key] [Column("IdCommission")]
    public int IdCommission { get; set; }
    [Column("FormationDate")]
    public DateTime FormationDate { get; set; }
    [Column("DissolutionDate")]
    public DateTime DissolutionDate { get; set; }
    [Column("ChairmanId")]
    public int ChairmanId { get; set; }
    [ForeignKey("ChairmanId")]
    public Employee? Chairman { get; set; }

    [NotMapped]
    public DateTimeOffset OffsetFormationDate
        => new DateTimeOffset(FormationDate);
    [NotMapped]
    public DateTimeOffset OffsetDissolutionDate
        => new DateTimeOffset(DissolutionDate);
}