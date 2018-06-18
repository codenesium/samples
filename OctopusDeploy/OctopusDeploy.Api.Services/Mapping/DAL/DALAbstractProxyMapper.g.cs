using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractProxyMapper
        {
                public virtual Proxy MapBOToEF(
                        BOProxy bo)
                {
                        Proxy efProxy = new Proxy();

                        efProxy.SetProperties(
                                bo.Id,
                                bo.JSON,
                                bo.Name);
                        return efProxy;
                }

                public virtual BOProxy MapEFToBO(
                        Proxy ef)
                {
                        var bo = new BOProxy();

                        bo.SetProperties(
                                ef.Id,
                                ef.JSON,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOProxy> MapEFToBO(
                        List<Proxy> records)
                {
                        List<BOProxy> response = new List<BOProxy>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6d0f9858523526f5d0305b80fc2bc814</Hash>
</Codenesium>*/