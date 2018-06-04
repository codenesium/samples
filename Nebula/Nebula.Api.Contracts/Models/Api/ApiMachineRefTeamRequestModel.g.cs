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
		{}

		public void SetProperties(
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
    <Hash>3a21d12806aec6695c520a8b22c32a87</Hash>
</Codenesium>*/