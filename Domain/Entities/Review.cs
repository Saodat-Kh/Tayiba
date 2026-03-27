using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.Entities;

public class Review : BaseEntities
{
    [Required]
    public string UserName { get; set; }
    public int Rating { get; set; } 
    [StringLength(300),MinLength(5)]
    public string Description { get; set; }
    public StatusReview? Status { get; set; }
    //navigation 
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
    
    
}