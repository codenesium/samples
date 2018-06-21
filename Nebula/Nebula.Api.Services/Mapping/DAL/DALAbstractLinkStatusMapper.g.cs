using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public abstract class DALAbstractLinkStatusMapper
        {
                public virtual LinkStatus MapBOToEF(
                        BOLinkStatus bo)
                {
                        LinkStatus efLinkStatus = new LinkStatus();
                        efLinkStatus.SetProperties(
                                bo.Id,
                                bo.Name);
                        return efLinkStatus;
                }

                public virtual BOLinkStatus MapEFToBO(
                        LinkStatus ef)
                {
                        var bo = new BOLinkStatus();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOLinkStatus> MapEFToBO(
                        List<LinkStatus> records)
                {
                        List<BOLinkStatus> response = new List<BOLinkStatus>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>3052f554e0025c30ac58473656754a2e</Hash>
</Codenesium>*/