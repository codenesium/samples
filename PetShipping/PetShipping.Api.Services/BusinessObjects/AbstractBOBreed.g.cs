using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOBreed : AbstractBusinessObject
        {
                public AbstractBOBreed()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string name,
                                                  int speciesId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.SpeciesId = speciesId;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int SpeciesId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a9ac763d656c72c0474a4a0c3e7208d0</Hash>
</Codenesium>*/