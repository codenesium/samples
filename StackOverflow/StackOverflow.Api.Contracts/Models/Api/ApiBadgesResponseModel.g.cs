using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public class ApiBadgesResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime date,
                        int id,
                        string name,
                        int userId)
                {
                        this.Date = date;
                        this.Id = id;
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
    <Hash>141866db17961b40ee8ef6dada709b4f</Hash>
</Codenesium>*/