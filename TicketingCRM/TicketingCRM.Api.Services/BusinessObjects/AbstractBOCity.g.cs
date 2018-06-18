using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOCity: AbstractBusinessObject
        {
                public AbstractBOCity() : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string name,
                                                  int provinceId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.ProvinceId = provinceId;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int ProvinceId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a849a303d948466cc1e9f856843bfc43</Hash>
</Codenesium>*/