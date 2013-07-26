using System.ComponentModel;

namespace DucksOnThePond.Core.Enums
{
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