using System;
using System.Runtime.Serialization;

namespace ApiApp.Models.Core
{
    [Flags, Serializable, DataContract]
    public enum Level
    {
        [EnumMember]
        Unknown = 0x8,
        [EnumMember]
        ElementarySchool = 0x0,
        [EnumMember]
        MiddleSchool = 0x1,
        [EnumMember]
        HighSchool = 0x2,
        [EnumMember]
        University = 0x4
    }

    [Serializable, DataContract]
    public enum Program
    {
        [EnumMember]
        Unknown,
        [EnumMember]
        VIQC,
        [EnumMember]
        VRC,
        [EnumMember]
        VEXU
    }

    [Serializable, DataContract]
    public enum Round
    {
        [EnumMember]
        Practice, // 0
        [EnumMember]
        Qualification, // 1
        [EnumMember]
        QuarterFinals, // 2
        [EnumMember]
        SemiFinals, // 3
        [EnumMember]
        Finals, // 4
        [EnumMember]
        EightFinals, // 5
        [EnumMember]
        RoundOf16, // 6
        [EnumMember]
        RoundOf32 // 7
    }
}