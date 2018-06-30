using Codenesium.DataConversionExtensions;
using System;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractBOPaymentType : AbstractBusinessObject
        {
                public AbstractBOPaymentType()
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
    <Hash>895ae5e4246120bce5f43ae49a1a31c3</Hash>
</Codenesium>*/