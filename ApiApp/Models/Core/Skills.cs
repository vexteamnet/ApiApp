using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Runtime.Serialization;

namespace ApiApp.Models.Core
{
    public class Skills
    {
        [Key, Required, Column(Order = 0), RegularExpression(Event.SKUREGEX), MaxLength(Event.SKULENGTH)]
        public string EventSku { get; set; }
        [ForeignKey(nameof(EventSku))]
        public virtual Event Event { get; set; }

        [Key, Required, Column(Order = 1), RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH)]
        public string TeamNumber { get; set; }
        [ForeignKey(nameof(TeamNumber))]
        public virtual Team Team { get; set; }

        [Key, Required, Column(Order = 2)]
        public SkillsType Type { get; set; }

        public int Score { get; set; }

        [IgnoreDataMember]
        public ExpandoObject ScoreDetails { get; set; }
        [Column("ScoreDetails")]
        public string ScoreDetailsString
        {
            get { return JsonConvert.SerializeObject(ScoreDetails); }
            set { ScoreDetails = JsonConvert.DeserializeObject<ExpandoObject>(value); }
        }

        public int Rank { get; set; }

        public int Attempts { get; set; }
    }

    public enum SkillsType
    {
        Robot,
        Programming
    }
}