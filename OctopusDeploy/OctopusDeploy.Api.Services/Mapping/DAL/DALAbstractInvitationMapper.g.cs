using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractInvitationMapper
        {
                public virtual Invitation MapBOToEF(
                        BOInvitation bo)
                {
                        Invitation efInvitation = new Invitation();

                        efInvitation.SetProperties(
                                bo.Id,
                                bo.InvitationCode,
                                bo.JSON);
                        return efInvitation;
                }

                public virtual BOInvitation MapEFToBO(
                        Invitation ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOInvitation();

                        bo.SetProperties(
                                ef.Id,
                                ef.InvitationCode,
                                ef.JSON);
                        return bo;
                }

                public virtual List<BOInvitation> MapEFToBO(
                        List<Invitation> records)
                {
                        List<BOInvitation> response = new List<BOInvitation>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>d2c60530eddd3a9d540e18ae4587cd83</Hash>
</Codenesium>*/