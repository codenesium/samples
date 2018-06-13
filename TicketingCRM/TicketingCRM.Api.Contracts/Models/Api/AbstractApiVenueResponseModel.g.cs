using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiVenueResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string address1,
                        string address2,
                        int adminId,
                        string email,
                        string facebook,
                        int id,
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
                        this.Id = id;
                        this.Name = name;
                        this.Phone = phone;
                        this.ProvinceId = provinceId;
                        this.Website = website;

                        this.AdminIdEntity = nameof(ApiResponse.Admins);
                        this.ProvinceIdEntity = nameof(ApiResponse.Provinces);
                }

                public string Address1 { get; private set; }

                public string Address2 { get; private set; }

                public int AdminId { get; private set; }

                public string AdminIdEntity { get; set; }

                public string Email { get; private set; }

                public string Facebook { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public string Phone { get; private set; }

                public int ProvinceId { get; private set; }

                public string ProvinceIdEntity { get; set; }

                public string Website { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAddress1Value { get; set; } = true;

                public bool ShouldSerializeAddress1()
                {
                        return this.ShouldSerializeAddress1Value;
                }

                [JsonIgnore]
                public bool ShouldSerializeAddress2Value { get; set; } = true;

                public bool ShouldSerializeAddress2()
                {
                        return this.ShouldSerializeAddress2Value;
                }

                [JsonIgnore]
                public bool ShouldSerializeAdminIdValue { get; set; } = true;

                public bool ShouldSerializeAdminId()
                {
                        return this.ShouldSerializeAdminIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEmailValue { get; set; } = true;

                public bool ShouldSerializeEmail()
                {
                        return this.ShouldSerializeEmailValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeFacebookValue { get; set; } = true;

                public bool ShouldSerializeFacebook()
                {
                        return this.ShouldSerializeFacebookValue;
                }

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
                public bool ShouldSerializePhoneValue { get; set; } = true;

                public bool ShouldSerializePhone()
                {
                        return this.ShouldSerializePhoneValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProvinceIdValue { get; set; } = true;

                public bool ShouldSerializeProvinceId()
                {
                        return this.ShouldSerializeProvinceIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeWebsiteValue { get; set; } = true;

                public bool ShouldSerializeWebsite()
                {
                        return this.ShouldSerializeWebsiteValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAddress1Value = false;
                        this.ShouldSerializeAddress2Value = false;
                        this.ShouldSerializeAdminIdValue = false;
                        this.ShouldSerializeEmailValue = false;
                        this.ShouldSerializeFacebookValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializePhoneValue = false;
                        this.ShouldSerializeProvinceIdValue = false;
                        this.ShouldSerializeWebsiteValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>ff1fd841bd9f25ad6125661d01f03193</Hash>
</Codenesium>*/