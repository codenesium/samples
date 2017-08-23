using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sample1NS.Api.Contracts
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
    <Hash>60bf3335e1480b56e816e5d6e3ed750a</Hash>
</Codenesium>*/