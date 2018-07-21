using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiProvinceResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int countryId,
                        string name)
                {
                        this.Id = id;
                        this.CountryId = countryId;
                        this.Name = name;

                        this.CountryIdEntity = nameof(ApiResponse.Countries);
                }

                [Required]
                [JsonProperty]
                public int CountryId { get; private set; }

                [JsonProperty]
                public string CountryIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0b8f89dc8c2d60a03077b9c01854504d</Hash>
</Codenesium>*/