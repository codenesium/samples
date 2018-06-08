using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Services
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
    <Hash>b47e9bb202cef4f69cb659ddd3b4575a</Hash>
</Codenesium>*/