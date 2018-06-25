using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NebulaNS.Api.DataAccess
{
        [Table("MachineRefTeam", Schema="dbo")]
        public partial class MachineRefTeam : AbstractEntity
        {
                public MachineRefTeam()
                {
                }

                public virtual void SetProperties(
                        int id,
                        int machineId,
                        int teamId)
                {
                        this.Id = id;
                        this.MachineId = machineId;
                        this.TeamId = teamId;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("machineId")]
                public int MachineId { get; private set; }

                [Column("teamId")]
                public int TeamId { get; private set; }

                [ForeignKey("MachineId")]
                public virtual Machine Machine { get; set; }

                [ForeignKey("TeamId")]
                public virtual Team Team { get; set; }
        }
}

/*<Codenesium>
    <Hash>a21315f4c0d46490f3a774d94d071750</Hash>
</Codenesium>*/