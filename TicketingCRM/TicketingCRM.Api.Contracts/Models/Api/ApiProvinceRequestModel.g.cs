using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiProvinceRequestModel : AbstractApiRequestModel
        {
                public ApiProvinceRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int countryId,
                        string name)
                {
                        this.CountryId = countryId;
                        this.Name = name;
                }

                [JsonProperty]
                public int CountryId { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>605d5266ea86161e4f7198e659e295f7</Hash>
</Codenesium>*/