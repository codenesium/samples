using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class DALAbstractLinkMapper
        {
                public virtual Link MapBOToEF(
                        BOLink bo)
                {
                        Link efLink = new Link();

                        efLink.SetProperties(
                                bo.AssignedMachineId,
                                bo.ChainId,
                                bo.DateCompleted,
                                bo.DateStarted,
                                bo.DynamicParameters,
                                bo.ExternalId,
                                bo.Id,
                                bo.LinkStatusId,
                                bo.Name,
                                bo.Order,
                                bo.Response,
                                bo.StaticParameters,
                                bo.TimeoutInSeconds);
                        return efLink;
                }

                public virtual BOLink MapEFToBO(
                        Link ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOLink();

                        bo.SetProperties(
                                ef.Id,
                                ef.AssignedMachineId,
                                ef.ChainId,
                                ef.DateCompleted,
                                ef.DateStarted,
                                ef.DynamicParameters,
                                ef.ExternalId,
                                ef.LinkStatusId,
                                ef.Name,
                                ef.Order,
                                ef.Response,
                                ef.StaticParameters,
                                ef.TimeoutInSeconds);
                        return bo;
                }

                public virtual List<BOLink> MapEFToBO(
                        List<Link> records)
                {
                        List<BOLink> response = new List<BOLink>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>c14154fcf79bfaac3a681c068d8d7c2a</Hash>
</Codenesium>*/