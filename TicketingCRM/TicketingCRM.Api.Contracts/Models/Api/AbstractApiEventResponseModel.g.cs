using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiEventResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string address1,
                        string address2,
                        int cityId,
                        DateTime date,
                        string description,
                        DateTime endDate,
                        string facebook,
                        int id,
                        string name,
                        DateTime startDate,
                        string website)
                {
                        this.Address1 = address1;
                        this.Address2 = address2;
                        this.CityId = cityId;
                        this.Date = date;
                        this.Description = description;
                        this.EndDate = endDate;
                        this.Facebook = facebook;
                        this.Id = id;
                        this.Name = name;
                        this.StartDate = startDate;
                        this.Website = website;

                        this.CityIdEntity = nameof(ApiResponse.Cities);
                }

                public string Address1 { get; private set; }

                public string Address2 { get; private set; }

                public int CityId { get; private set; }

                public string CityIdEntity { get; set; }

                public DateTime Date { get; private set; }

                public string Description { get; private set; }

                public DateTime EndDate { get; private set; }

                public string Facebook { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public DateTime StartDate { get; private set; }

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
                public bool ShouldSerializeCityIdValue { get; set; } = true;

                public bool ShouldSerializeCityId()
                {
                        return this.ShouldSerializeCityIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDateValue { get; set; } = true;

                public bool ShouldSerializeDate()
                {
                        return this.ShouldSerializeDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDescriptionValue { get; set; } = true;

                public bool ShouldSerializeDescription()
                {
                        return this.ShouldSerializeDescriptionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEndDateValue { get; set; } = true;

                public bool ShouldSerializeEndDate()
                {
                        return this.ShouldSerializeEndDateValue;
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
                public bool ShouldSerializeStartDateValue { get; set; } = true;

                public bool ShouldSerializeStartDate()
                {
                        return this.ShouldSerializeStartDateValue;
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
                        this.ShouldSerializeCityIdValue = false;
                        this.ShouldSerializeDateValue = false;
                        this.ShouldSerializeDescriptionValue = false;
                        this.ShouldSerializeEndDateValue = false;
                        this.ShouldSerializeFacebookValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeStartDateValue = false;
                        this.ShouldSerializeWebsiteValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>af45122296148a3f2e36d8a899307696</Hash>
</Codenesium>*/