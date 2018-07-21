using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiVenueRequestModel : AbstractApiRequestModel
        {
                public ApiVenueRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string address1,
                        string address2,
                        int adminId,
                        string email,
                        string facebook,
                        string name,
                        string phone,
                        int provinceId,
                        string website)
                {
                        this.Address1 = address1;
                        this.Address2 = address2;
                        this.AdminId = adminId;
                        this.Email = email;
                        this.Facebook = facebook;
                        this.Name = name;
                        this.Phone = phone;
                        this.ProvinceId = provinceId;
                        this.Website = website;
                }

                [JsonProperty]
                public string Address1 { get; private set; }

                [JsonProperty]
                public string Address2 { get; private set; }

                [JsonProperty]
                public int AdminId { get; private set; }

                [JsonProperty]
                public string Email { get; private set; }

                [JsonProperty]
                public string Facebook { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public string Phone { get; private set; }

                [JsonProperty]
                public int ProvinceId { get; private set; }

                [JsonProperty]
                public string Website { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e881bf709011362808b4a27ab5b4c7b8</Hash>
</Codenesium>*/