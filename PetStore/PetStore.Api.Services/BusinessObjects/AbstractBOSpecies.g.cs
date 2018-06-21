using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractBOSpecies : AbstractBusinessObject
        {
                public AbstractBOSpecies()
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
    <Hash>f13b31cc2bce77329e5a6a2321f23156</Hash>
</Codenesium>*/