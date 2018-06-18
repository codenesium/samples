using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractBOMachineRefTeam: AbstractBusinessObject
        {
                public AbstractBOMachineRefTeam() : base()
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
    <Hash>5d8c42a8bb7d9f8f276abf05c6390004</Hash>
</Codenesium>*/