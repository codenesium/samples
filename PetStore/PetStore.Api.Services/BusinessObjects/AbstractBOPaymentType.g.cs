using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractBOPaymentType: AbstractBusinessObject
        {
                public AbstractBOPaymentType() : base()
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
    <Hash>4bfcfea97e0f6e24d9e849835065057a</Hash>
</Codenesium>*/