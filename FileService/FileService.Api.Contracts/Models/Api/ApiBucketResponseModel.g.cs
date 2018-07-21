using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
        public partial class ApiBucketResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        Guid externalId,
                        string name)
                {
                        this.Id = id;
                        this.ExternalId = externalId;
                        this.Name = name;
                }

                [Required]
                [JsonProperty]
                public Guid ExternalId { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>edf8caa644176c98f246d57a9d51bd8a</Hash>
</Codenesium>*/