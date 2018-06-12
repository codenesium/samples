using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
                        if (ef == null)
                        {
                                return null;
                        }

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
    <Hash>a2a49327d91a275bfaa7cdee62edeca3</Hash>
</Codenesium>*/