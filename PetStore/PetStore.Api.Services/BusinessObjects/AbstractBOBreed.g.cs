using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractBOBreed: AbstractBusinessObject
        {
                public AbstractBOBreed() : base()
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
    <Hash>b4a67f47ef91328e20489a82404e0787</Hash>
</Codenesium>*/