using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileServiceNS.Api.DataAccess
{
        [Table("VersionInfo", Schema="dbo")]
        public partial class VersionInfo : AbstractEntity
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

                [Column("AppliedOn")]
                public Nullable<DateTime> AppliedOn { get; private set; }

                [Column("Description")]
                public string Description { get; private set; }

                [Key]
                [Column("Version")]
                public long Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6920e2bc35f4e128aefdb37564a70aeb</Hash>
</Codenesium>*/