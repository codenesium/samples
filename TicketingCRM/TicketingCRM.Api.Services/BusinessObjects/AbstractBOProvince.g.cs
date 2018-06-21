using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOProvince : AbstractBusinessObject
        {
                public AbstractBOProvince()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  int countryId,
                                                  string name)
                {
                        this.CountryId = countryId;
                        this.Id = id;
                        this.Name = name;
                }

                public int CountryId { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9a1b19d632a18fd229354c4dfa5bbb25</Hash>
</Codenesium>*/