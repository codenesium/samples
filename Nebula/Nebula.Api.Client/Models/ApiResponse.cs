using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NebulaNS.Api.Client
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Chains.ForEach(x => this.AddChain(x));
			from.ChainStatus.ForEach(x => this.AddChainStatus(x));
			from.Clasps.ForEach(x => this.AddClasp(x));
			from.Links.ForEach(x => this.AddLink(x));
			from.LinkLogs.ForEach(x => this.AddLinkLog(x));
			from.LinkStatus.ForEach(x => this.AddLinkStatus(x));
			from.Machines.ForEach(x => this.AddMachine(x));
			from.Organizations.ForEach(x => this.AddOrganization(x));
			from.Teams.ForEach(x => this.AddTeam(x));
		}

		public List<ApiChainClientResponseModel> Chains { get; private set; } = new List<ApiChainClientResponseModel>();

		public List<ApiChainStatusClientResponseModel> ChainStatus { get; private set; } = new List<ApiChainStatusClientResponseModel>();

		public List<ApiClaspClientResponseModel> Clasps { get; private set; } = new List<ApiClaspClientResponseModel>();

		public List<ApiLinkClientResponseModel> Links { get; private set; } = new List<ApiLinkClientResponseModel>();

		public List<ApiLinkLogClientResponseModel> LinkLogs { get; private set; } = new List<ApiLinkLogClientResponseModel>();

		public List<ApiLinkStatusClientResponseModel> LinkStatus { get; private set; } = new List<ApiLinkStatusClientResponseModel>();

		public List<ApiMachineClientResponseModel> Machines { get; private set; } = new List<ApiMachineClientResponseModel>();

		public List<ApiOrganizationClientResponseModel> Organizations { get; private set; } = new List<ApiOrganizationClientResponseModel>();

		public List<ApiTeamClientResponseModel> Teams { get; private set; } = new List<ApiTeamClientResponseModel>();

		public void AddChain(ApiChainClientResponseModel item)
		{
			if (!this.Chains.Any(x => x.Id == item.Id))
			{
				this.Chains.Add(item);
			}
		}

		public void AddChainStatus(ApiChainStatusClientResponseModel item)
		{
			if (!this.ChainStatus.Any(x => x.Id == item.Id))
			{
				this.ChainStatus.Add(item);
			}
		}

		public void AddClasp(ApiClaspClientResponseModel item)
		{
			if (!this.Clasps.Any(x => x.Id == item.Id))
			{
				this.Clasps.Add(item);
			}
		}

		public void AddLink(ApiLinkClientResponseModel item)
		{
			if (!this.Links.Any(x => x.Id == item.Id))
			{
				this.Links.Add(item);
			}
		}

		public void AddLinkLog(ApiLinkLogClientResponseModel item)
		{
			if (!this.LinkLogs.Any(x => x.Id == item.Id))
			{
				this.LinkLogs.Add(item);
			}
		}

		public void AddLinkStatus(ApiLinkStatusClientResponseModel item)
		{
			if (!this.LinkStatus.Any(x => x.Id == item.Id))
			{
				this.LinkStatus.Add(item);
			}
		}

		public void AddMachine(ApiMachineClientResponseModel item)
		{
			if (!this.Machines.Any(x => x.Id == item.Id))
			{
				this.Machines.Add(item);
			}
		}

		public void AddOrganization(ApiOrganizationClientResponseModel item)
		{
			if (!this.Organizations.Any(x => x.Id == item.Id))
			{
				this.Organizations.Add(item);
			}
		}

		public void AddTeam(ApiTeamClientResponseModel item)
		{
			if (!this.Teams.Any(x => x.Id == item.Id))
			{
				this.Teams.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>b6bbd018232d1e1369c2ed6b90dbbb2e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/