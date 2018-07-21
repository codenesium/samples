using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiMachineRefTeamRequestModel : AbstractApiRequestModel
        {
                public ApiMachineRefTeamRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int machineId,
                        int teamId)
                {
                        this.MachineId = machineId;
                        this.TeamId = teamId;
                }

                [JsonProperty]
                public int MachineId { get; private set; }

                [JsonProperty]
                public int TeamId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>60da0c501707ffd4515e029b8a1a0c72</Hash>
</Codenesium>*/