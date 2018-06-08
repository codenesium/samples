using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOSpecies: AbstractBusinessObject
        {
                public BOSpecies() : base()
                {
                }

                public void SetProperties(int id,
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
    <Hash>42e1ba1b286f11bfec7621a5b5f10ca0</Hash>
</Codenesium>*/