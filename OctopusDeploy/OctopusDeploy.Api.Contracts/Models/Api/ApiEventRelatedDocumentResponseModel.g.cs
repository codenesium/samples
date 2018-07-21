using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiEventRelatedDocumentResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string eventId,
                        string relatedDocumentId)
                {
                        this.Id = id;
                        this.EventId = eventId;
                        this.RelatedDocumentId = relatedDocumentId;

                        this.EventIdEntity = nameof(ApiResponse.Events);
                }

                [Required]
                [JsonProperty]
                public string EventId { get; private set; }

                [JsonProperty]
                public string EventIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string RelatedDocumentId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>cd0c99103e86884dfe9c6dd0d38b4ec6</Hash>
</Codenesium>*/