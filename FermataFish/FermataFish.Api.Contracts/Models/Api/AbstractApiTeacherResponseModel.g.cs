using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiTeacherResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime birthday,
                        string email,
                        string firstName,
                        int id,
                        string lastName,
                        string phone,
                        int studioId)
                {
                        this.Birthday = birthday;
                        this.Email = email;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.Phone = phone;
                        this.StudioId = studioId;

                        this.StudioIdEntity = nameof(ApiResponse.Studios);
                }

                public DateTime Birthday { get; private set; }

                public string Email { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public string LastName { get; private set; }

                public string Phone { get; private set; }

                public int StudioId { get; private set; }

                public string StudioIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeBirthdayValue { get; set; } = true;

                public bool ShouldSerializeBirthday()
                {
                        return this.ShouldSerializeBirthdayValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEmailValue { get; set; } = true;

                public bool ShouldSerializeEmail()
                {
                        return this.ShouldSerializeEmailValue;
                }

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
                public bool ShouldSerializeLastNameValue { get; set; } = true;

                public bool ShouldSerializeLastName()
                {
                        return this.ShouldSerializeLastNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePhoneValue { get; set; } = true;

                public bool ShouldSerializePhone()
                {
                        return this.ShouldSerializePhoneValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStudioIdValue { get; set; } = true;

                public bool ShouldSerializeStudioId()
                {
                        return this.ShouldSerializeStudioIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBirthdayValue = false;
                        this.ShouldSerializeEmailValue = false;
                        this.ShouldSerializeFirstNameValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLastNameValue = false;
                        this.ShouldSerializePhoneValue = false;
                        this.ShouldSerializeStudioIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>4483d349aa88e2bf25abb7d4abd2c5f4</Hash>
</Codenesium>*/