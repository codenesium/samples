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

                public string EventId { get; private set; }

                public string EventIdEntity { get; set; }

                public int Id { get; private set; }

                public string RelatedDocumentId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>aebf8077f764a9d4c57c8b71ad163285</Hash>
</Codenesium>*/