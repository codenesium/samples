using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>8d8eed57c5e21043f0e231ae7b0bc3ed</Hash>
</Codenesium>*/