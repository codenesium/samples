using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public partial class BOTransactionStatus: AbstractBusinessObject
        {
                public BOTransactionStatus() : base()
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
    <Hash>26e8746365ad33b3597d4cafc4c36487</Hash>
</Codenesium>*/