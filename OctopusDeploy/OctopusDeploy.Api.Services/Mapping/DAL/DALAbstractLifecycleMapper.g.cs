using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractLifecycleMapper
        {
                public virtual Lifecycle MapBOToEF(
                        BOLifecycle bo)
                {
                        Lifecycle efLifecycle = new Lifecycle();
                        efLifecycle.SetProperties(
                                bo.DataVersion,
                                bo.Id,
                                bo.JSON,
                                bo.Name);
                        return efLifecycle;
                }

                public virtual BOLifecycle MapEFToBO(
                        Lifecycle ef)
                {
                        var bo = new BOLifecycle();

                        bo.SetProperties(
                                ef.Id,
                                ef.DataVersion,
                                ef.JSON,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOLifecycle> MapEFToBO(
                        List<Lifecycle> records)
                {
                        List<BOLifecycle> response = new List<BOLifecycle>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>de8ab1cccce909f267d53c31e1cdf090</Hash>
</Codenesium>*/