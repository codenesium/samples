using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("MachinePolicy", Schema="dbo")]
        public partial class MachinePolicy: AbstractEntity
        {
                public MachinePolicy()
                {
                }

                public void SetProperties(
                        string id,
                        bool isDefault,
                        string jSON,
                        string name)
                {
                        this.Id = id;
                        this.IsDefault = isDefault;
                        this.JSON = jSON;
                        this.Name = name;
                }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("IsDefault", TypeName="bit")]
                public bool IsDefault { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>809d921cb29b86ccb1c7726fa7c6327b</Hash>
</Codenesium>*/