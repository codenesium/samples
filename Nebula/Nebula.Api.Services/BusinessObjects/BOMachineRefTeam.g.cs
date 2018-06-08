using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public partial class BOMachineRefTeam: AbstractBusinessObject
        {
                public BOMachineRefTeam() : base()
                {
                }

                public void SetProperties(int id,
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
    <Hash>026350311e199654bc1a0cdb8b13144b</Hash>
</Codenesium>*/