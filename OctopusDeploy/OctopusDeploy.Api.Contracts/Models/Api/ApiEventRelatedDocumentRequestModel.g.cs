using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiEventRelatedDocumentRequestModel: AbstractApiRequestModel
        {
                public ApiEventRelatedDocumentRequestModel() : base()
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
    <Hash>2097e66553b62a48b46ae29e65a8f32a</Hash>
</Codenesium>*/