using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public partial class BOCity:AbstractBusinessObject
        {
                public BOCity() : base()
                {
                }

                public void SetProperties(int id,
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
    <Hash>1e33dee4323db8ba5b9f2e160c4ca356</Hash>
</Codenesium>*/