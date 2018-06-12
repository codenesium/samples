using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractEventRelatedDocumentMapper
        {
                public virtual EventRelatedDocument MapBOToEF(
                        BOEventRelatedDocument bo)
                {
                        EventRelatedDocument efEventRelatedDocument = new EventRelatedDocument();

                        efEventRelatedDocument.SetProperties(
                                bo.EventId,
                                bo.Id,
                                bo.RelatedDocumentId);
                        return efEventRelatedDocument;
                }

                public virtual BOEventRelatedDocument MapEFToBO(
                        EventRelatedDocument ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOEventRelatedDocument();

                        bo.SetProperties(
                                ef.Id,
                                ef.EventId,
                                ef.RelatedDocumentId);
                        return bo;
                }

                public virtual List<BOEventRelatedDocument> MapEFToBO(
                        List<EventRelatedDocument> records)
                {
                        List<BOEventRelatedDocument> response = new List<BOEventRelatedDocument>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6254fe75e966456259e7047fa19258ff</Hash>
</Codenesium>*/