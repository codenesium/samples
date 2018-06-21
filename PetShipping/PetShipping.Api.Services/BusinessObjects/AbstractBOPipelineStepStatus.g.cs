using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOPipelineStepStatus : AbstractBusinessObject
        {
                public AbstractBOPipelineStepStatus()
                        : base()
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
    <Hash>beb47a193c8ab97ca26f280be94d049f</Hash>
</Codenesium>*/