using System;
using System.ComponentModel.DataAnnotations;

namespace PanelDeControl.Models;

public class Link
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Url]
    [StringLength(1000)]
    public string Url { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(100)]
    public string? Category { get; set; }

    // Tags separados por comas (simplificado)
    public string? Tags { get; set; }

    public bool IsFavorite { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
