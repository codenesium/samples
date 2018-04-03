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
    <Hash>42d1798f48bfb6634d64e582b892b86e</Hash>
</Codenesium>*/