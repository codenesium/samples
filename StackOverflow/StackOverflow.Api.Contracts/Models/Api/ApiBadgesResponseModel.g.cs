using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiBadgesResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        DateTime date,
                        string name,
                        int userId)
                {
                        this.Id = id;
                        this.Date = date;
                        this.Name = name;
                        this.UserId = userId;
                }

                public DateTime Date { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int UserId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeDateValue { get; set; } = true;

                public bool ShouldSerializeDate()
                {
                        return this.ShouldSerializeDateValue;
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
                public bool ShouldSerializeUserIdValue { get; set; } = true;

                public bool ShouldSerializeUserId()
                {
                        return this.ShouldSerializeUserIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDateValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeUserIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>f5df05dd5c240cc46a6239ae1390f6d7</Hash>
</Codenesium>*/