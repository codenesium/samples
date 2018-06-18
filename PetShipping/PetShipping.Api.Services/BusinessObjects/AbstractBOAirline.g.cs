using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOAirline: AbstractBusinessObject
        {
                public AbstractBOAirline() : base()
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
    <Hash>e3b2dbd098d17a72ff979951ef80c7a0</Hash>
</Codenesium>*/