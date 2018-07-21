using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
        public partial class ApiPersonRefResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int personAId,
                        int personBId)
                {
                        this.Id = id;
                        this.PersonAId = personAId;
                        this.PersonBId = personBId;

                        this.PersonBIdEntity = nameof(ApiResponse.SchemaBPersons);
                }

                [JsonProperty]
                public int Id { get; private set; }

                [JsonProperty]
                public int PersonAId { get; private set; }

                [JsonProperty]
                public int PersonBId { get; private set; }

                [JsonProperty]
                public string PersonBIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>ff3663200401f1e6d59fe9a9ae9c8e40</Hash>
</Codenesium>*/