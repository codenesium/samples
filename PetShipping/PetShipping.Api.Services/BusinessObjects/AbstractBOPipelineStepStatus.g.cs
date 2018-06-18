using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOPipelineStepStatus: AbstractBusinessObject
        {
                public AbstractBOPipelineStepStatus() : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7bc139b17c6a538d2ebae1f363eb7579</Hash>
</Codenesium>*/