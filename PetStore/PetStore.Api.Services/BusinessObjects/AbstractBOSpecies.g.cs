using Codenesium.DataConversionExtensions;
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
    <Hash>52ebbb8fefca7cb19882b58ca18aa26f</Hash>
</Codenesium>*/