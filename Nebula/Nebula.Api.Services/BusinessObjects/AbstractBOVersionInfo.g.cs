using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractBOVersionInfo : AbstractBusinessObject
        {
                public AbstractBOVersionInfo()
                        : base()
                {
                }

                public virtual void SetProperties(long version,
                                                  DateTime? appliedOn,
                                                  string description)
                {
                        this.AppliedOn = appliedOn;
                        this.Description = description;
                        this.Version = version;
                }

                public DateTime? AppliedOn { get; private set; }

                public string Description { get; private set; }

                public long Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5370be04475070292f8ee0eb9b1583c9</Hash>
</Codenesium>*/