using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace NebulaNS.Api.Contracts
{
	public class ReferenceEntity<T>
	{
		public T Value { get; set; }

		public string Href
		{
			get
			{
				return $"/{this.ReferenceObjectName}/{this.Value.ToString()}";
			}
		}

		public string ReferenceObjectName { get; set; }

		public ReferenceEntity(T value, string referenceObjectName)
		{
			this.Value = value;
			this.ReferenceObjectName = referenceObjectName;
		}
	}

	public partial class Response
	{
		public Response()
		{}
		public List<POCOChain> Chains { get; private set; } = new List<POCOChain>();

		public List<POCOChainStatus> ChainStatus { get; private set; } = new List<POCOChainStatus>();

		public List<POCOClasp> Clasps { get; private set; } = new List<POCOClasp>();

		public List<POCOLink> Links { get; private set; } = new List<POCOLink>();

		public List<POCOLinkLog> LinkLogs { get; private set; } = new List<POCOLinkLog>();

		public List<POCOLinkStatus> LinkStatus { get; private set; } = new List<POCOLinkStatus>();

		public List<POCOMachine> Machines { get; private set; } = new List<POCOMachine>();

		public List<POCOMachineRefTeam> MachineRefTeams { get; private set; } = new List<POCOMachineRefTeam>();

		public List<POCOOrganization> Organizations { get; private set; } = new List<POCOOrganization>();

		public List<POCOTeam> Teams { get; private set; } = new List<POCOTeam>();

		[JsonIgnore]
		public bool ShouldSerializeChainsValue { get; set; } = true;

		public bool ShouldSerializeChains()
		{
			return this.ShouldSerializeChainsValue;
		}

		public void AddChain(POCOChain item)
		{
			if (!this.Chains.Any(x => x.Id == item.Id))
			{
				this.Chains.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeChainStatusValue { get; set; } = true;

		public bool ShouldSerializeChainStatus()
		{
			return this.ShouldSerializeChainStatusValue;
		}

		public void AddChainStatus(POCOChainStatus item)
		{
			if (!this.ChainStatus.Any(x => x.Id == item.Id))
			{
				this.ChainStatus.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeClaspsValue { get; set; } = true;

		public bool ShouldSerializeClasps()
		{
			return this.ShouldSerializeClaspsValue;
		}

		public void AddClasp(POCOClasp item)
		{
			if (!this.Clasps.Any(x => x.Id == item.Id))
			{
				this.Clasps.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLinksValue { get; set; } = true;

		public bool ShouldSerializeLinks()
		{
			return this.ShouldSerializeLinksValue;
		}

		public void AddLink(POCOLink item)
		{
			if (!this.Links.Any(x => x.Id == item.Id))
			{
				this.Links.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLinkLogsValue { get; set; } = true;

		public bool ShouldSerializeLinkLogs()
		{
			return this.ShouldSerializeLinkLogsValue;
		}

		public void AddLinkLog(POCOLinkLog item)
		{
			if (!this.LinkLogs.Any(x => x.Id == item.Id))
			{
				this.LinkLogs.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLinkStatusValue { get; set; } = true;

		public bool ShouldSerializeLinkStatus()
		{
			return this.ShouldSerializeLinkStatusValue;
		}

		public void AddLinkStatus(POCOLinkStatus item)
		{
			if (!this.LinkStatus.Any(x => x.Id == item.Id))
			{
				this.LinkStatus.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeMachinesValue { get; set; } = true;

		public bool ShouldSerializeMachines()
		{
			return this.ShouldSerializeMachinesValue;
		}

		public void AddMachine(POCOMachine item)
		{
			if (!this.Machines.Any(x => x.Id == item.Id))
			{
				this.Machines.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeMachineRefTeamsValue { get; set; } = true;

		public bool ShouldSerializeMachineRefTeams()
		{
			return this.ShouldSerializeMachineRefTeamsValue;
		}

		public void AddMachineRefTeam(POCOMachineRefTeam item)
		{
			if (!this.MachineRefTeams.Any(x => x.Id == item.Id))
			{
				this.MachineRefTeams.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeOrganizationsValue { get; set; } = true;

		public bool ShouldSerializeOrganizations()
		{
			return this.ShouldSerializeOrganizationsValue;
		}

		public void AddOrganization(POCOOrganization item)
		{
			if (!this.Organizations.Any(x => x.Id == item.Id))
			{
				this.Organizations.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTeamsValue { get; set; } = true;

		public bool ShouldSerializeTeams()
		{
			return this.ShouldSerializeTeamsValue;
		}

		public void AddTeam(POCOTeam item)
		{
			if (!this.Teams.Any(x => x.Id == item.Id))
			{
				this.Teams.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.Chains.Count == 0)
			{
				this.ShouldSerializeChainsValue = false;
			}

			if (this.ChainStatus.Count == 0)
			{
				this.ShouldSerializeChainStatusValue = false;
			}

			if (this.Clasps.Count == 0)
			{
				this.ShouldSerializeClaspsValue = false;
			}

			if (this.Links.Count == 0)
			{
				this.ShouldSerializeLinksValue = false;
			}

			if (this.LinkLogs.Count == 0)
			{
				this.ShouldSerializeLinkLogsValue = false;
			}

			if (this.LinkStatus.Count == 0)
			{
				this.ShouldSerializeLinkStatusValue = false;
			}

			if (this.Machines.Count == 0)
			{
				this.ShouldSerializeMachinesValue = false;
			}

			if (this.MachineRefTeams.Count == 0)
			{
				this.ShouldSerializeMachineRefTeamsValue = false;
			}

			if (this.Organizations.Count == 0)
			{
				this.ShouldSerializeOrganizationsValue = false;
			}

			if (this.Teams.Count == 0)
			{
				this.ShouldSerializeTeamsValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>95e562a2a9c4d7937ff43fe8d501615c</Hash>
</Codenesium>*/