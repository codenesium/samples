using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractMutexMapper
        {
                public virtual Mutex MapBOToEF(
                        BOMutex bo)
                {
                        Mutex efMutex = new Mutex();
                        efMutex.SetProperties(
                                bo.Id,
                                bo.JSON);
                        return efMutex;
                }

                public virtual BOMutex MapEFToBO(
                        Mutex ef)
                {
                        var bo = new BOMutex();

                        bo.SetProperties(
                                ef.Id,
                                ef.JSON);
                        return bo;
                }

                public virtual List<BOMutex> MapEFToBO(
                        List<Mutex> records)
                {
                        List<BOMutex> response = new List<BOMutex>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ec2e37fb73dbfdb543bed12e8675335a</Hash>
</Codenesium>*/