using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Runtime.Serialization;

namespace ApiApp.Models
{
    public class Match
    {
        [Key, Required, Column(Order = 0), RegularExpression(Event.SKUREGEX), MaxLength(Event.SKULENGTH)]
        public string EventSku { get; set; }
        [Key, Required, Column(Order = 1)]
        public string DivisionName { get; set; }
        [ForeignKey(nameof(EventSku) + "," + nameof(DivisionName))]
        public virtual Division Division { get; set; }

        [Key, Required, Column(Order = 2)]
        public Round Round { get; set; }
        
        [Key, Required, Column(Order = 3)]
        public int Instance { get; set; }

        [Key, Required, Column(Order = 4)]
        public int Number { get; set; }

        public DateTime Scheduled { get; set; }
        public string Field { get; set; }

        public int RedScore { get; set; }
        public int BlueScore { get; set; }

        [IgnoreDataMember]
        public ExpandoObject RedScoreDetails { get; set; }
        [Column("RedScoreDetails")]
        public string RedScoreString
        {
            get { return JsonConvert.SerializeObject(RedScoreDetails); }
            set { RedScoreDetails = JsonConvert.DeserializeObject<ExpandoObject>(value); }
        }

        [IgnoreDataMember]
        public ExpandoObject BlueScoreDetails { get; set; }
        [Column("BlueScoreDetails")]
        public string BlueScoreString
        {
            get { return JsonConvert.SerializeObject(BlueScoreDetails); }
            set { BlueScoreDetails = JsonConvert.DeserializeObject<ExpandoObject>(value); }
        }

        public bool OfficialScored { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH)]
        public string Red1Number { get; set; }
        [ForeignKey(nameof(Red1Number))]
        public virtual Team Red1 { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH)]
        public string Red2Number { get; set; }
        [ForeignKey(nameof(Red2Number))]
        public virtual Team Red2 { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH)]
        public string Red3Number { get; set; }
        [ForeignKey(nameof(Red3Number))]
        public virtual Team Red3 { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH)]
        public string RedSitNumber { get; set; }
        [ForeignKey(nameof(RedSitNumber))]
        public virtual Team RedSit { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH)]
        public string Blue1Number { get; set; }
        [ForeignKey(nameof(Blue1Number))]
        public virtual Team Blue1 { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH)]
        public string Blue2Number { get; set; }
        [ForeignKey(nameof(Blue2Number))]
        public virtual Team Blue2 { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH)]
        public string Blue3Number { get; set; }
        [ForeignKey(nameof(Blue3Number))]
        public virtual Team Blue3 { get; set; }

        [RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH)]
        public string BlueSitNumber { get; set; }
        [ForeignKey(nameof(BlueSitNumber))]
        public virtual Team BlueSit { get; set; }
    }
}
