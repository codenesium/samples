using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
        public abstract class AbstractBOSelfReference : AbstractBusinessObject
        {
                public AbstractBOSelfReference()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  int? selfReferenceId,
                                                  int? selfReferenceId2)
                {
                        this.Id = id;
                        this.SelfReferenceId = selfReferenceId;
                        this.SelfReferenceId2 = selfReferenceId2;
                }

                public int Id { get; private set; }

                public int? SelfReferenceId { get; private set; }

                public int? SelfReferenceId2 { get; private set; }
        }
}

/*<Codenesium>
    <Hash>01bd3187032bf1c11e1f3036dd2a4570</Hash>
</Codenesium>*/