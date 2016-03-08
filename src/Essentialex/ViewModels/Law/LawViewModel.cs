using System;
using Essentialex.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Essentialex.ViewModels.Law
{

    public class LawViewModel 
    {
        [Required]
        public string LawName { get; set; }

        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime LawDate { get; set; }

        public DateTime DigitalVersionDate { get; set; }

        [Required]
        public string Body { get; set; }

        public string Publication { get; set; }

        public string Kind { get; set; }

        public string Valid { get; set; }

        public int Count { get; set; }

    }
}
