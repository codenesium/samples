using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Services
{
        public partial class BOPaymentType: AbstractBusinessObject
        {
                public BOPaymentType() : base()
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
    <Hash>1b93a70b19f3e8363751592cf14294b6</Hash>
</Codenesium>*/