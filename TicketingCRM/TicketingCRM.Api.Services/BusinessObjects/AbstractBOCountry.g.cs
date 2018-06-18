using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOCountry: AbstractBusinessObject
        {
                public AbstractBOCountry() : base()
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
    <Hash>9115dc7a8da2f04e1ac17303f2a3e4fe</Hash>
</Codenesium>*/