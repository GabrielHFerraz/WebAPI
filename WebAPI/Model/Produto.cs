using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Model;

[Table("Produto")]
public class Produto
{
    [Column]
    public int Id { get; set; }
    public string Nome { get; set; } = String.Empty;
}