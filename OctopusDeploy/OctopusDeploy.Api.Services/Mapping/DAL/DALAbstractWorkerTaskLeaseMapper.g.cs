using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>d205c2bb8913b70425ec82cde86597ae</Hash>
</Codenesium>*/