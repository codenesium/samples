using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiMachineRefTeamResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int machineId,
                        int teamId)
                {
                        this.Id = id;
                        this.MachineId = machineId;
                        this.TeamId = teamId;

                        this.MachineIdEntity = nameof(ApiResponse.Machines);
                        this.TeamIdEntity = nameof(ApiResponse.Teams);
                }

                public int Id { get; private set; }

                public int MachineId { get; private set; }

                public string MachineIdEntity { get; set; }

                public int TeamId { get; private set; }

                public string TeamIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>aebbaccf94217cd1bd4bc6fb9c1865ad</Hash>
</Codenesium>*/