using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DucksOnThePond.Core.Enums;

namespace DucksOnThePond.Core.Models
{
    public class Player
    {
        public virtual int Id { get; set; }
        public virtual int Number { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}