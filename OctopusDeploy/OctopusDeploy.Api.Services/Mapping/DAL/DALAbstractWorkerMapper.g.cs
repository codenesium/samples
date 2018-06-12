using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractWorkerMapper
        {
                public virtual Worker MapBOToEF(
                        BOWorker bo)
                {
                        Worker efWorker = new Worker();

                        efWorker.SetProperties(
                                bo.CommunicationStyle,
                                bo.Fingerprint,
                                bo.Id,
                                bo.IsDisabled,
                                bo.JSON,
                                bo.MachinePolicyId,
                                bo.Name,
                                bo.RelatedDocumentIds,
                                bo.Thumbprint,
                                bo.WorkerPoolIds);
                        return efWorker;
                }

                public virtual BOWorker MapEFToBO(
                        Worker ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOWorker();

                        bo.SetProperties(
                                ef.Id,
                                ef.CommunicationStyle,
                                ef.Fingerprint,
                                ef.IsDisabled,
                                ef.JSON,
                                ef.MachinePolicyId,
                                ef.Name,
                                ef.RelatedDocumentIds,
                                ef.Thumbprint,
                                ef.WorkerPoolIds);
                        return bo;
                }

                public virtual List<BOWorker> MapEFToBO(
                        List<Worker> records)
                {
                        List<BOWorker> response = new List<BOWorker>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4bc0f546ee55542ee75a773f5831aea6</Hash>
</Codenesium>*/