using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace career_api_server.Models;

[Index("Code", IsUnique = true)]
public class CompanyMaster {

    public int Id { get; set; } = 0;
    [StringLength(10)]
    public string Code { get; set; } = string.Empty;
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
    public bool CodingRoles { get; set; } = false;
    public bool ItbaRoles { get; set; } = false;
    public bool SecurityRoles { get; set; } = false;
    public bool BlendedRoles { get; set; } = false;
    public bool VirtualRoles { get; set; } = false;

    public bool Active { get; set; } = true;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Updated { get; set; } = null;

}
