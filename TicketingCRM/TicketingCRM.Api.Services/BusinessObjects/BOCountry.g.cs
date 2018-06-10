using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public partial class BOCountry: AbstractBusinessObject
        {
                public BOCountry() : base()
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
    <Hash>fdcfa687ad4f081a5fbdf64d367a0e0a</Hash>
</Codenesium>*/