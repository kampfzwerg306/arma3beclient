using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arma3BEService.Lib.ModelCompact
{
    public class PlayerHistory
    {
        public PlayerHistory()
        {
            Date = DateTime.UtcNow;
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid PlayerId { get; set; }


      
        public string Name { get; set; }

        
        public string IP { get; set; }

   
        public DateTime Date { get; set; }

        public Guid ServerId { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        [ForeignKey("ServerId")]
        public virtual ServerInfo ServerInfo { get; set; }
    }
}