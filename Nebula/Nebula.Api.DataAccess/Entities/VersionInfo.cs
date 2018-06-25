using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NebulaNS.Api.DataAccess
{
        [Table("VersionInfo", Schema="dbo")]
        public partial class VersionInfo : AbstractEntity
        {
                public VersionInfo()
                {
                }

                public virtual void SetProperties(
                        DateTime? appliedOn,
                        string description,
                        long version)
                {
                        this.AppliedOn = appliedOn;
                        this.Description = description;
                        this.Version = version;
                }

                [Column("AppliedOn")]
                public DateTime? AppliedOn { get; private set; }

                [Column("Description")]
                public string Description { get; private set; }

                [Key]
                [Column("Version")]
                public long Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>db85402ac523c8c4001898815e075d2b</Hash>
</Codenesium>*/