using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOPipelineStatus: AbstractBusinessObject
        {
                public AbstractBOPipelineStatus() : base()
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
    <Hash>2c95ca34bc000d55b9877b95008f8d34</Hash>
</Codenesium>*/