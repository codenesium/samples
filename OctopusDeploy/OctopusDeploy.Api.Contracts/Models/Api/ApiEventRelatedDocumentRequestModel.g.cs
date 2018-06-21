using Codenesium.DataConversionExtensions;
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
    <Hash>8d5e693607407877205618d6d67fabac</Hash>
</Codenesium>*/