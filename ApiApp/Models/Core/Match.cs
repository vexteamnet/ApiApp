using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ApiApp.Models.Core
{
    [DataContract]
    public class Match
    {
        [Key, Required, Column(Order = 0), RegularExpression(Event.SKUREGEX), MaxLength(Event.SKULENGTH), DataMember]
        public string EventSku { get; set; }
        [Key, Required, Column(Order = 1), DataMember]
        public string DivisionName { get; set; }
        [ForeignKey(nameof(EventSku) + "," + nameof(DivisionName)), IgnoreDataMember]
        public virtual Division Division { get; set; }

        [Key, Required, Column(Order = 2), DataMember]
        public Round Round { get; set; }

        [Key, Required, Column(Order = 3), DataMember]
        public int Instance { get; set; }

        [Key, Required, Column(Order = 4), DataMember]
        public int Number { get; set; }

        //[Key, Required, Column(Order = 5), DefaultValue(0)]
        //public int Replay { get; set; } = 0;

        [DataMember]
        public DateTime? Scheduled { get; set; }
        [DataMember]
        public string Field { get; set; }

        [DataMember]
        public int RedScore { get; set; }
        [DataMember]
        public int BlueScore { get; set; }

        [IgnoreDataMember]
        public dynamic RedScoreDetails { get; set; }
        [Column("RedScoreDetails"), DataMember]
        public string RedScoreString
        {
            get { return JsonConvert.SerializeObject(RedScoreDetails); }
            set { if (value != null) RedScoreDetails = JsonConvert.DeserializeObject<dynamic>(value); }
        }

        [IgnoreDataMember]
        public dynamic BlueScoreDetails { get; set; }
        [Column("BlueScoreDetails"), DataMember]
        public string BlueScoreString
        {
            get { return JsonConvert.SerializeObject(BlueScoreDetails); }
            set { if (value != null) BlueScoreDetails = JsonConvert.DeserializeObject<dynamic>(value); }
        }

        [DataMember]
        public bool OfficialScored { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH), DataMember]
        public string Red1Number { get; set; }
        [ForeignKey(nameof(Red1Number)), IgnoreDataMember]
        public virtual Team Red1 { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH), DataMember]
        public string Red2Number { get; set; }
        [ForeignKey(nameof(Red2Number)), IgnoreDataMember]
        public virtual Team Red2 { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH), DataMember]
        public string Red3Number { get; set; }
        [ForeignKey(nameof(Red3Number)), IgnoreDataMember]
        public virtual Team Red3 { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH), DataMember]
        public string RedSitNumber { get; set; }
        [ForeignKey(nameof(RedSitNumber)), IgnoreDataMember]
        public virtual Team RedSit { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH), DataMember]
        public string Blue1Number { get; set; }
        [ForeignKey(nameof(Blue1Number)), IgnoreDataMember]
        public virtual Team Blue1 { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH), DataMember]
        public string Blue2Number { get; set; }
        [ForeignKey(nameof(Blue2Number)), IgnoreDataMember]
        public virtual Team Blue2 { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH), DataMember]
        public string Blue3Number { get; set; }
        [ForeignKey(nameof(Blue3Number)), IgnoreDataMember]
        public virtual Team Blue3 { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH), DataMember]
        public string BlueSitNumber { get; set; }
        [ForeignKey(nameof(BlueSitNumber)), IgnoreDataMember]
        public virtual Team BlueSit { get; set; }
    }
}