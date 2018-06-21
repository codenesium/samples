using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOEventRelatedDocument : AbstractBusinessObject
        {
                public AbstractBOEventRelatedDocument()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>9cc11b5fb29069e1df69071128e96702</Hash>
</Codenesium>*/