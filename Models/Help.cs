using System;
using System.ComponentModel.DataAnnotations;

namespace career_api_server.Models {

    public class Help {

        public int Id { get; set; } = 0;
        public string Topic { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;

        public bool Active { get; set; } = true;
        public DateTime? Created { get; set; } = null;
        public DateTime? Updated { get; set; } = null;
    }
}

