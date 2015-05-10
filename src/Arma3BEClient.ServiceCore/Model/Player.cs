//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arma3BEClient.ServiceCore.Model
{
    public partial class Player
    {
        public Player()
        {
            this.LastSeen = DateTime.UtcNow;

            this.Notes = new HashSet<Note>();
            this.PlayerHistory = new HashSet<PlayerHistory>();
           // this.Sessions = new HashSet<Sessions>();
        }
    
        [Key]
        public System.Guid Id { get; set; }

        public string GUID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string LastIp { get; set; }
        public DateTime LastSeen { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Ban> Bans { get; set; }
        public virtual ICollection<PlayerHistory> PlayerHistory { get; set; }


        
    }
}
