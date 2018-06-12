using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Account", Schema="dbo")]
        public partial class Account: AbstractEntity
        {
                public Account()
                {
                }

                public void SetProperties(
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

                [Column("AccountType", TypeName="nvarchar(50)")]
                public string AccountType { get; private set; }

                [Column("EnvironmentIds", TypeName="nvarchar(-1)")]
                public string EnvironmentIds { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(210)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("TenantIds", TypeName="nvarchar(-1)")]
                public string TenantIds { get; private set; }

                [Column("TenantTags", TypeName="nvarchar(-1)")]
                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>093d107545492b685f18a166e521eb51</Hash>
</Codenesium>*/