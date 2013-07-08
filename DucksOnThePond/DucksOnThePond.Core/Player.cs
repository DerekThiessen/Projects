using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DucksOnThePond.Core
{
    public class Player : Person
    {
        public int Number { get; set; }
        public List<FieldPosition> Positions { get; set; }
    }

    public enum FieldPosition : int
    {
        [Description("P")]
        Pitcher,
        [Description("C")]
        Catcher,
        [Description("1B")]
        FirstBase,
        [Description("2B")]
        SecondBase,
        [Description("3B")]
        ThirdBase,
        [Description("SS")]
        ShortStop,
        [Description("LF")]
        LeftField,
        [Description("CF")]
        CenterField,
        [Description("RF")]
        RightField
    }
}