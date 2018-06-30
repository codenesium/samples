using Codenesium.DataConversionExtensions;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOTransactionStatus : AbstractBusinessObject
        {
                public AbstractBOTransactionStatus()
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
    <Hash>9f3b38c28d97acb41032fd742c4d61c7</Hash>
</Codenesium>*/