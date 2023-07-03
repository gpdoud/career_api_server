using Microsoft.EntityFrameworkCore;

namespace career_api_server.Models;

[Index("Type", Name = "UIDX_Type", IsUnique = true)]
public class ActivityType {
    public int Id { get; set; }
    public string Type{ get; set; } // Resume: Submitted
    public string Description { get; set; } // used when submitting a resume3

    public bool Active { get; set; } = true;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Updated { get; set; } = null;
}
