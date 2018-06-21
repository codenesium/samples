using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NebulaNS.Api.DataAccess
{
        [Table("Machine", Schema="dbo")]
        public partial class Machine : AbstractEntity
        {
                public Machine()
                {
                }

                public void SetProperties(
                        string description,
                        int id,
                        string jwtKey,
                        string lastIpAddress,
                        Guid machineGuid,
                        string name)
                {
                        this.Description = description;
                        this.Id = id;
                        this.JwtKey = jwtKey;
                        this.LastIpAddress = lastIpAddress;
                        this.MachineGuid = machineGuid;
                        this.Name = name;
                }

                [Column("description")]
                public string Description { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("jwtKey")]
                public string JwtKey { get; private set; }

                [Column("lastIpAddress")]
                public string LastIpAddress { get; private set; }

                [Column("machineGuid")]
                public Guid MachineGuid { get; private set; }

                [Column("name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8236302e8238dd0e28700d8fe34d5ef6</Hash>
</Codenesium>*/