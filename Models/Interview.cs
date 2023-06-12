namespace career_api_server.Models;

public class Interview {
    public int Id { get; set; }
    public DateTime FirstInterview { get; set; }
    public DateTime FirstFollowUpLetter { get; set; }
    public DateTime FirstFollowUpCall { get; set; }
    public DateTime SecondInterview { get; set; }
    public DateTime SecondFollowUpLetter { get; set; }
    public DateTime SecondFollowUpCall { get; set; }

    public bool Active { get; set; } = true;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Updated { get; set; } = null;
}
