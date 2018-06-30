using Codenesium.DataConversionExtensions;
using System;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractBOBreed : AbstractBusinessObject
        {
                public AbstractBOBreed()
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
    <Hash>e6b7a62d4c3dc89d2855387bbef261c5</Hash>
</Codenesium>*/