using Codenesium.DataConversionExtensions;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOCity : AbstractBusinessObject
        {
                public AbstractBOCity()
                        : base()
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
    <Hash>3df6ccd0cc6b65fd6342925e496e9cc6</Hash>
</Codenesium>*/