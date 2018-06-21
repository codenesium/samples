using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractBOMachineRefTeam : AbstractBusinessObject
        {
                public AbstractBOMachineRefTeam()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  int machineId,
                                                  int teamId)
                {
                        this.Id = id;
                        this.MachineId = machineId;
                        this.TeamId = teamId;
                }

                public int Id { get; private set; }

                public int MachineId { get; private set; }

                public int TeamId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7e2b668b72681352fdf67dbe558b695b</Hash>
</Codenesium>*/