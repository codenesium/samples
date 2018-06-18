using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOSpecies: AbstractBusinessObject
        {
                public AbstractBOSpecies() : base()
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
    <Hash>d1d7b3c6eea79332dc1c100c1b249d9f</Hash>
</Codenesium>*/