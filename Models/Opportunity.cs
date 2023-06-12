using System.ComponentModel.DataAnnotations;

namespace career_api_server.Models;

public class Opportunity {
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int CompanyId { get; set; }
    public virtual Company Company { get; set; }
    public char Rank { get; set; } = 'C';
    public int CompanyConnectionId { get; set; }
    public virtual CompanyConnection CompanyConnection { get; set; }
    public string Notes { get; set; }

    public bool Active { get; set; } = true;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Updated { get; set; } = null;
}
