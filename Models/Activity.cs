using System.Text.Json.Serialization;

namespace career_api_server.Models;

public class Activity {
    public int Id { get; set; }
    public int OpportunityId { get; set; }
    [JsonIgnore]
    public virtual Opportunity Opportunity { get; set; }
    public int ActivityTypeId { get; set; }
    public virtual ActivityType ActivityType { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; }

    public bool Active { get; set; } = true;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Updated { get; set; } = null;
}
