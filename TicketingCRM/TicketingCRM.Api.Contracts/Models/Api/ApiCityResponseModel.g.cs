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

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProvinceIdValue { get; set; } = true;

                public bool ShouldSerializeProvinceId()
                {
                        return this.ShouldSerializeProvinceIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeProvinceIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>979ed1a32896bca6df482b03e33e3181</Hash>
</Codenesium>*/