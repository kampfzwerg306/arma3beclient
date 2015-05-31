using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arma3BEService.Lib.ModelCompact
{
    public class Ban
    {
        [Key]
        public int Id { get; set; }

        public Guid? PlayerId { get; set; }
        
        public int Num { get; set; }

        public Guid ServerId { get; set; }

        public string GuidIp { get; set; }
        
        public int Minutes { get; set; }
       
        public int MinutesLeft { get; set; }
      
        public string Reason { get; set; }

        public DateTime CreateDate { get; set; }
        
        public bool IsActive { get; set; }


        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        [ForeignKey("ServerId")]
        public virtual ServerInfo ServerInfo { get; set; }


        public Ban()
        {
            CreateDate = DateTime.UtcNow;
            IsActive = true;
        }
    }
}