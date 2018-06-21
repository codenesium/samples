using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("MachinePolicy", Schema="dbo")]
        public partial class MachinePolicy : AbstractEntity
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
                [Column("Id")]
                public string Id { get; private set; }

                [Column("IsDefault")]
                public bool IsDefault { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d2dbf54de539095af3fbca16d77de95b</Hash>
</Codenesium>*/