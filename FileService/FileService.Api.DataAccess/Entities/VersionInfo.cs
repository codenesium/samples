using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FileServiceNS.Api.DataAccess
{
        [Table("VersionInfo", Schema="dbo")]
        public partial class VersionInfo: AbstractEntity
        {
                public VersionInfo()
                {
                }

                public void SetProperties(
                        Nullable<DateTime> appliedOn,
                        string description,
                        long version)
                {
                        this.AppliedOn = appliedOn;
                        this.Description = description;
                        this.Version = version;
                }

                [Column("AppliedOn", TypeName="datetime")]
                public Nullable<DateTime> AppliedOn { get; private set; }

                [Column("Description", TypeName="nvarchar(1024)")]
                public string Description { get; private set; }

                [Key]
                [Column("Version", TypeName="bigint")]
                public long Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>51c7012582ea409f0bb16faa45bd0842</Hash>
</Codenesium>*/