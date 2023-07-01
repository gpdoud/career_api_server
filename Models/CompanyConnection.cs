using System.ComponentModel.DataAnnotations;

namespace career_api_server.Models;

public class CompanyConnection {
    public int Id { get; set; }
    [StringLength(50)]
    public string Connection { get; set; }

    public bool Active { get; set; } = true;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Updated { get; set; } = null;
}
