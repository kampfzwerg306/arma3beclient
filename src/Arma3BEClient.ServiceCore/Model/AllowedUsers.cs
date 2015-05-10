using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arma3BEClient.ServiceCore.Model
{
    public class AllowedUsers
    {
        public AllowedUsers()
        {

        }

        [Key]
        public System.Guid Id { get; set; }

        public Guid ServerId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("ServerId")]
        public virtual ServerInfo ServerInfo { get; set; }
    }
}
