using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiEmployeeResponseModel: AbstractApiResponseModel
        {
                public ApiEmployeeResponseModel() : base()
                {
                }

                public void SetProperties(
                        string firstName,
                        int id,
                        bool isSalesPerson,
                        bool isShipper,
                        string lastName)
                {
                        this.FirstName = firstName;
                        this.Id = id;
                        this.IsSalesPerson = isSalesPerson;
                        this.IsShipper = isShipper;
                        this.LastName = lastName;
                }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public bool IsSalesPerson { get; private set; }

                public bool IsShipper { get; private set; }

                public string LastName { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeFirstNameValue { get; set; } = true;

                public bool ShouldSerializeFirstName()
                {
                        return this.ShouldSerializeFirstNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIsSalesPersonValue { get; set; } = true;

                public bool ShouldSerializeIsSalesPerson()
                {
                        return this.ShouldSerializeIsSalesPersonValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIsShipperValue { get; set; } = true;

                public bool ShouldSerializeIsShipper()
                {
                        return this.ShouldSerializeIsShipperValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLastNameValue { get; set; } = true;

                public bool ShouldSerializeLastName()
                {
                        return this.ShouldSerializeLastNameValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeFirstNameValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeIsSalesPersonValue = false;
                        this.ShouldSerializeIsShipperValue = false;
                        this.ShouldSerializeLastNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>ba7b01e9eec1a304635335a2a85c0f9f</Hash>
</Codenesium>*/