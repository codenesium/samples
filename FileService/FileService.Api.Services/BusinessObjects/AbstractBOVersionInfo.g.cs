using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Services
{
        public abstract class AbstractBOVersionInfo: AbstractBusinessObject
        {
                public AbstractBOVersionInfo() : base()
                {
                }

                public virtual void SetProperties(long version,
                                                  Nullable<DateTime> appliedOn,
                                                  string description)
                {
                        this.AppliedOn = appliedOn;
                        this.Description = description;
                        this.Version = version;
                }

                public Nullable<DateTime> AppliedOn { get; private set; }

                public string Description { get; private set; }

                public long Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9f0c4b1116696b0564aed0a6fdcfb7e9</Hash>
</Codenesium>*/