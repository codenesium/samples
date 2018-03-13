using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace NebulaNS.Api.Contracts
{
	public partial class MachineRefTeamModel
	{
		public MachineRefTeamModel()
		{}

		public MachineRefTeamModel(int id,
		                           int machineId,
		                           int teamId)
		{
			this.Id = id.ToInt();
			this.MachineId = machineId.ToInt();
			this.TeamId = teamId.ToInt();
		}

		public MachineRefTeamModel(POCOMachineRefTeam poco)
		{
			this.Id = poco.Id.ToInt();

			MachineId = poco.MachineId.Value.ToInt();
			TeamId = poco.TeamId.Value.ToInt();
		}

		private int _id;
		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				this._id = value;
			}
		}

		private int _machineId;
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
    <Hash>c0fac6ead70ecc0aa8a2145d1c6113b8</Hash>
</Codenesium>*/