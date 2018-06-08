using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public partial class BOChainStatus: AbstractBusinessObject
        {
                public BOChainStatus() : base()
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
    <Hash>3755b3677793e074c417ba0e079499a1</Hash>
</Codenesium>*/