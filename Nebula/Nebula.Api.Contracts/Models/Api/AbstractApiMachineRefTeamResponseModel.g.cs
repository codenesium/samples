using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiMachineRefTeamResponseModel : AbstractApiResponseModel
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

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeMachineIdValue { get; set; } = true;

                public bool ShouldSerializeMachineId()
                {
                        return this.ShouldSerializeMachineIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTeamIdValue { get; set; } = true;

                public bool ShouldSerializeTeamId()
                {
                        return this.ShouldSerializeTeamIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeMachineIdValue = false;
                        this.ShouldSerializeTeamIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>1a04ba8e9d9bff542417138cd30618e1</Hash>
</Codenesium>*/