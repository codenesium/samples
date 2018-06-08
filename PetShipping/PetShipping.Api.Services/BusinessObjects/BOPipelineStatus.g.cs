using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOPipelineStatus: AbstractBusinessObject
        {
                public BOPipelineStatus() : base()
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
    <Hash>572a938c9ef99f0aab4b103e5b1c19ef</Hash>
</Codenesium>*/