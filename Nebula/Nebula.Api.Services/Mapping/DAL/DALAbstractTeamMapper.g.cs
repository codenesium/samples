using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class DALAbstractTeamMapper
        {
                public virtual Team MapBOToEF(
                        BOTeam bo)
                {
                        Team efTeam = new Team();

                        efTeam.SetProperties(
                                bo.Id,
                                bo.Name,
                                bo.OrganizationId);
                        return efTeam;
                }

                public virtual BOTeam MapEFToBO(
                        Team ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOTeam();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name,
                                ef.OrganizationId);
                        return bo;
                }

                public virtual List<BOTeam> MapEFToBO(
                        List<Team> records)
                {
                        List<BOTeam> response = new List<BOTeam>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>c59b161a89394415fa297de6970ade28</Hash>
</Codenesium>*/