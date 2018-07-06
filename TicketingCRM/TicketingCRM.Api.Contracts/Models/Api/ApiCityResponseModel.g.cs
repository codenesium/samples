using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiCityResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        int provinceId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.ProvinceId = provinceId;

                        this.ProvinceIdEntity = nameof(ApiResponse.Provinces);
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int ProvinceId { get; private set; }

                public string ProvinceIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>a15047eae22d51861a19896986721ca6</Hash>
</Codenesium>*/