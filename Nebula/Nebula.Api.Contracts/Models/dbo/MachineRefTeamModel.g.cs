using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class MachineRefTeamModel
	{
		public MachineRefTeamModel()
		{}

		public MachineRefTeamModel(int machineId,
		                           int teamId)
		{
			this.MachineId = machineId.ToInt();
			this.TeamId = teamId.ToInt();
		}

		public MachineRefTeamModel(POCOMachineRefTeam poco)
		{
			this.MachineId = poco.MachineId.Value.ToInt();
			this.TeamId = poco.TeamId.Value.ToInt();
		}

		private int _machineId;
		[Required]
		public int MachineId
		{
			get
			{
				return _machineId;
			}
			set
			{
				this._machineId = value;
			}
		}

		private int _teamId;
		[Required]
		public int TeamId
		{
			get
			{
				return _teamId;
			}
			set
			{
				this._teamId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>8d0aa4d040f60f675dbe340eb683c805</Hash>
</Codenesium>*/