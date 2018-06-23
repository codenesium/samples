using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public class ApiEmployeeResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
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

                public virtual void DisableAllFields()
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
    <Hash>56481a814560b341545bc9720e18c875</Hash>
</Codenesium>*/