using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractWorkerTaskLeaseMapper
        {
                public virtual WorkerTaskLease MapBOToEF(
                        BOWorkerTaskLease bo)
                {
                        WorkerTaskLease efWorkerTaskLease = new WorkerTaskLease();
                        efWorkerTaskLease.SetProperties(
                                bo.Exclusive,
                                bo.Id,
                                bo.JSON,
                                bo.Name,
                                bo.TaskId,
                                bo.WorkerId);
                        return efWorkerTaskLease;
                }

                public virtual BOWorkerTaskLease MapEFToBO(
                        WorkerTaskLease ef)
                {
                        var bo = new BOWorkerTaskLease();

                        bo.SetProperties(
                                ef.Id,
                                ef.Exclusive,
                                ef.JSON,
                                ef.Name,
                                ef.TaskId,
                                ef.WorkerId);
                        return bo;
                }

                public virtual List<BOWorkerTaskLease> MapEFToBO(
                        List<WorkerTaskLease> records)
                {
                        List<BOWorkerTaskLease> response = new List<BOWorkerTaskLease>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>96f822146f1d33a08a3e36ad90185ab3</Hash>
</Codenesium>*/