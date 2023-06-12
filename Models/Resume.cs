namespace career_api_server.Models;

public class Resume {
    public int Id { get; set; }
    public int OpportunityId { get; set; }
    public virtual Opportunity Opportunity { get; set; }
    public DateTime SubmittedToCompany { get; set; }
    public DateTime FollowUpDate { get; set; }
    public string EmployerResponse { get; set; }

    public bool Active { get; set; } = true;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Updated { get; set; } = null;
}
