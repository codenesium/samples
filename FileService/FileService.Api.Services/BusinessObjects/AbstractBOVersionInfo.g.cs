using Codenesium.DataConversionExtensions;
using System;

namespace FileServiceNS.Api.Services
{
        public abstract class AbstractBOVersionInfo : AbstractBusinessObject
        {
                public AbstractBOVersionInfo()
                        : base()
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
    <Hash>706107e0f9533b2120937b3905130aa9</Hash>
</Codenesium>*/