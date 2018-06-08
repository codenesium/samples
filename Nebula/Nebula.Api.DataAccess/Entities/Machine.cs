using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
        [Table("Machine", Schema="dbo")]
        public partial class Machine: AbstractEntity
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

                [Column("description", TypeName="text(2147483647)")]
                public string Description { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("jwtKey", TypeName="varchar(128)")]
                public string JwtKey { get; private set; }

                [Column("lastIpAddress", TypeName="varchar(128)")]
                public string LastIpAddress { get; private set; }

                [Column("machineGuid", TypeName="uniqueidentifier")]
                public Guid MachineGuid { get; private set; }

                [Column("name", TypeName="varchar(128)")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>df3db9a88830b67fe8714fb3a5d82ffa</Hash>
</Codenesium>*/