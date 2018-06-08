using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Services
{
        public partial class BOVersionInfo: AbstractBusinessObject
        {
                public BOVersionInfo() : base()
                {
                }

                public void SetProperties(long version,
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
    <Hash>351ea550661cf288bf72835dc7dd2289</Hash>
</Codenesium>*/