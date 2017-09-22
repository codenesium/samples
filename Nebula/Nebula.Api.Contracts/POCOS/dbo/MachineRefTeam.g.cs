using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Spatial;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOMachineRefTeam
	{
		public POCOMachineRefTeam()
		{}

		public POCOMachineRefTeam(int id,
		                          int machineId,
		                          int teamId)
		{
			this.Id = id.ToInt();

			MachineId = new ReferenceEntity<int>(machineId,
			                                     "Machine");
			TeamId = new ReferenceEntity<int>(teamId,
			                                  "Team");
		}

		public int Id {get; set;}
		public ReferenceEntity<int>MachineId {get; set;}
		public ReferenceEntity<int>TeamId {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMachineIdValue {get; set;} = true;

		public bool ShouldSerializeMachineId()
		{
			return ShouldSerializeMachineIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTeamIdValue {get; set;} = true;

		public bool ShouldSerializeTeamId()
		{
			return ShouldSerializeTeamIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeMachineIdValue = false;
			this.ShouldSerializeTeamIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>d6faaf911640875fd71e4fb70d074e03</Hash>
</Codenesium>*/