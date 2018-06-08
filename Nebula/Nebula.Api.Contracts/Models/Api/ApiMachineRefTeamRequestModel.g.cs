using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiMachineRefTeamRequestModel: AbstractApiRequestModel
        {
                public ApiMachineRefTeamRequestModel() : base()
                {
                }

                public void SetProperties(
                        int machineId,
                        int teamId)
                {
                        this.MachineId = machineId;
                        this.TeamId = teamId;
                }

                private int machineId;

                [Required]
                public int MachineId
                {
                        get
                        {
                                return this.machineId;
                        }

                        set
                        {
                                this.machineId = value;
                        }
                }

                private int teamId;

                [Required]
                public int TeamId
                {
                        get
                        {
                                return this.teamId;
                        }

                        set
                        {
                                this.teamId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>65c0a01edc288eca8a48be49ca1007fb</Hash>
</Codenesium>*/