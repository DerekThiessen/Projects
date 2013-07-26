using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DucksOnThePond.Core.Enums;

namespace DucksOnThePond.Core
{
    public class Player : Person
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<FieldPosition> Positions { get; set; }
    }
}