using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
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
    <Hash>50b9f052eacda93e639b0feac87d0fb9</Hash>
</Codenesium>*/