using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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
    <Hash>fa9d5fbd34952570c13e58eb580ba600</Hash>
</Codenesium>*/