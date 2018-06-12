using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOEventRelatedDocument: AbstractBusinessObject
        {
                public BOEventRelatedDocument() : base()
                {
                }

                public void SetProperties(int id,
                                          string eventId,
                                          string relatedDocumentId)
                {
                        this.EventId = eventId;
                        this.Id = id;
                        this.RelatedDocumentId = relatedDocumentId;
                }

                public string EventId { get; private set; }

                public int Id { get; private set; }

                public string RelatedDocumentId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9f0d244642ca40c11a9730b0bf8aeaf0</Hash>
</Codenesium>*/