using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Services
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
    <Hash>9bbc3e3717b0a9be549d63e3ff5a5854</Hash>
</Codenesium>*/