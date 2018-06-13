using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiCityRequestModel: AbstractApiRequestModel
        {
                public ApiCityRequestModel() : base()
                {
                }

                public void SetProperties(
                        string name,
                        int provinceId)
                {
                        this.Name = name;
                        this.ProvinceId = provinceId;
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private int provinceId;

                [Required]
                public int ProvinceId
                {
                        get
                        {
                                return this.provinceId;
                        }

                        set
                        {
                                this.provinceId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>43f409f16aea34211f84de2eeea13c17</Hash>
</Codenesium>*/