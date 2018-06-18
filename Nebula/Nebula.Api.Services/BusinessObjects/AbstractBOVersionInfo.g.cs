using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
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
    <Hash>e6e850697b53554df4d806ccc50ab6bd</Hash>
</Codenesium>*/