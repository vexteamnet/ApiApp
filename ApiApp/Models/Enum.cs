using System;

namespace ApiApp.Models
{
    [Flags]
    public enum Level
    {
        ElementarySchool = 0x0,
        MiddleSchool = 0x1,
        HighSchool = 0x2,
        University = 0x3
    }

    public enum Program
    {
        VIQC,
        VRC,
        VEXU
    }

    public enum Round
    {
        Practice,
        Qualification,
        QuarterFinals,
        SemiFinals,
        Finals
    }
}