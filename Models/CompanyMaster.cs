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
    public string CompanyName { get; set; } = string.Empty;
    [StringLength(50)]
    public string Address { get; set; } = string.Empty;
    [StringLength(50)]
    public string City { get; set; } = string.Empty;
    [StringLength(2)]
    public string StateCode { get; set; } = string.Empty;
    [StringLength(10)]
    public string Zip { get; set; } = string.Empty;
    [StringLength(50)]
    public string ContactName { get; set; } = string.Empty;
    [StringLength(20)]
    public string ContactPhone { get; set; } = string.Empty;
    
    public bool Active { get; set; } = true;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Updated { get; set; } = null;

}
