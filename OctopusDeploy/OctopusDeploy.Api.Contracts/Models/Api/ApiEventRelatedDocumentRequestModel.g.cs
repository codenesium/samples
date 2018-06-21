using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiEventRelatedDocumentRequestModel : AbstractApiRequestModel
        {
                public ApiEventRelatedDocumentRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string eventId,
                        string relatedDocumentId)
                {
                        this.EventId = eventId;
                        this.RelatedDocumentId = relatedDocumentId;
                }

                private string eventId;

                [Required]
                public string EventId
                {
                        get
                        {
                                return this.eventId;
                        }

                        set
                        {
                                this.eventId = value;
                        }
                }

                private string relatedDocumentId;

                [Required]
                public string RelatedDocumentId
                {
                        get
                        {
                                return this.relatedDocumentId;
                        }

                        set
                        {
                                this.relatedDocumentId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>6b4c1381ba60296fa187d3fba3c2e29c</Hash>
</Codenesium>*/