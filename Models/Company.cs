using System.ComponentModel.DataAnnotations;

namespace career_api_server.Models;

public class Company {
    public int Id { get; set; }
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [StringLength(50)]
    public string? Address { get; set; } = null;
    [StringLength(50)]
    public string? City { get; set; } = null;
    [StringLength(2)]
    public string? StateCode { get; set; } = null;
    [StringLength(10)]
    public string? Zip { get; set; } = null;
    [StringLength(12)]
    public string? Phone { get; set; } = null;
    [StringLength(100)]
    public string? Email { get; set; } = null;
    [StringLength(100)]
    public string? Website { get; set; } = null;
    [StringLength(50)]
    public string? ContactName { get; set; } = null;
    [StringLength(20)]
    public string? ContactPhone { get; set; } = null;
    [StringLength(50)]
    public string? ContactRole { get; set; } = null;

    public int UserId { get; set; }
    public virtual User? User { get; set; }

    public bool Active { get; set; } = true;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Updated { get; set; } = null;

    public static Company CreateInstance(CompanyMaster cm) {
        var c = new Company {
            Id = 0,
            Name = cm.Name,
            Address = cm.Address,
            City = cm.City,
            StateCode = cm.StateCode,
            Zip = cm.Zip,
            Phone = cm.Phone,
            Email = cm.Email,
            Website = cm.Website,
            ContactName = cm.ContactName,
            ContactPhone = cm.ContactPhone,
            ContactRole = cm.ContactRole,

            Active = cm.Active
        };


        return c;
    }
}
