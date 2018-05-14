using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiMachineRefTeamModel
	{
		public ApiMachineRefTeamModel()
		{}

		public ApiMachineRefTeamModel(
			int machineId,
			int teamId)
		{
			this.MachineId = machineId.ToInt();
			this.TeamId = teamId.ToInt();
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
    <Hash>4a99c4204026a0816b786c7b672e4a96</Hash>
</Codenesium>*/