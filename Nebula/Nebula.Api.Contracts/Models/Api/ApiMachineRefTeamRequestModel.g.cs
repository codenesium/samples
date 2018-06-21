using Codenesium.DataConversionExtensions;
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
    <Hash>73f4478ba024d6cef3b19a45f8cabc97</Hash>
</Codenesium>*/