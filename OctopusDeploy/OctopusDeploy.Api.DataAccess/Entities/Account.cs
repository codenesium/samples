using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Account", Schema="dbo")]
        public partial class Account : AbstractEntity
        {
                public Account()
                {
                }

                public virtual void SetProperties(
                        string accountType,
                        string environmentIds,
                        string id,
                        string jSON,
                        string name,
                        string tenantIds,
                        string tenantTags)
                {
                        this.AccountType = accountType;
                        this.EnvironmentIds = environmentIds;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                }

                [Column("AccountType")]
                public string AccountType { get; private set; }

                [Column("EnvironmentIds")]
                public string EnvironmentIds { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("TenantIds")]
                public string TenantIds { get; private set; }

                [Column("TenantTags")]
                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>66c0c320b224c256c0b858bbc7ed0548</Hash>
</Codenesium>*/