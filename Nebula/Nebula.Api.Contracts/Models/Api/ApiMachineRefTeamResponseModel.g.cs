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

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public int MachineId { get; private set; }

                [JsonProperty]
                public string MachineIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int TeamId { get; private set; }

                [JsonProperty]
                public string TeamIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>60b2575fe6c2a519dc4874d08a9537a6</Hash>
</Codenesium>*/