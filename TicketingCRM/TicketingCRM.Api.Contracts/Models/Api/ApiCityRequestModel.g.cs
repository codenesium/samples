using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiCityRequestModel : AbstractApiRequestModel
        {
                public ApiCityRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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
    <Hash>71aed4b5e89eb1853522f9e0fba0984c</Hash>
</Codenesium>*/