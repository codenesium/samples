using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOTransactionStatus: AbstractBusinessObject
        {
                public AbstractBOTransactionStatus() : base()
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
    <Hash>536128be26ae11c0c97013ceb588fd40</Hash>
</Codenesium>*/