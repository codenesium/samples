using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class DALAbstractMachineRefTeamMapper
        {
                public virtual MachineRefTeam MapBOToEF(
                        BOMachineRefTeam bo)
                {
                        MachineRefTeam efMachineRefTeam = new MachineRefTeam();

                        efMachineRefTeam.SetProperties(
                                bo.Id,
                                bo.MachineId,
                                bo.TeamId);
                        return efMachineRefTeam;
                }

                public virtual BOMachineRefTeam MapEFToBO(
                        MachineRefTeam ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOMachineRefTeam();

                        bo.SetProperties(
                                ef.Id,
                                ef.MachineId,
                                ef.TeamId);
                        return bo;
                }

                public virtual List<BOMachineRefTeam> MapEFToBO(
                        List<MachineRefTeam> records)
                {
                        List<BOMachineRefTeam> response = new List<BOMachineRefTeam>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e07018289e73bff9c4963d6b80d16fc0</Hash>
</Codenesium>*/