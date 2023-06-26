using System;
using System.ComponentModel.DataAnnotations;

public class TaskModel
{
    public int ID { get; set; }
    [Required(AllowEmptyStrings = false)]
    public string Descripcion { get; set; }
    [Required]
    public DateTime FechaCreacion { get; set; }
    [Required(AllowEmptyStrings = false)]
    public string Estado { get; set; }
    [Required]
    public int Prioridad { get; set; }
}
