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
    <Hash>d5d2b37e4f858fe3a855e5e74cb2bbbb</Hash>
</Codenesium>*/