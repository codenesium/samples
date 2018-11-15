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
			from.ChainStatuses.ForEach(x => this.AddChainStatus(x));
			from.Links.ForEach(x => this.AddLink(x));
			from.LinkLogs.ForEach(x => this.AddLinkLog(x));
			from.LinkStatuses.ForEach(x => this.AddLinkStatus(x));
			from.Machines.ForEach(x => this.AddMachine(x));
			from.Organizations.ForEach(x => this.AddOrganization(x));
			from.Teams.ForEach(x => this.AddTeam(x));
			from.VersionInfoes.ForEach(x => this.AddVersionInfo(x));
		}

		public List<ApiChainStatusClientResponseModel> ChainStatuses { get; private set; } = new List<ApiChainStatusClientResponseModel>();

		public List<ApiLinkClientResponseModel> Links { get; private set; } = new List<ApiLinkClientResponseModel>();

		public List<ApiLinkLogClientResponseModel> LinkLogs { get; private set; } = new List<ApiLinkLogClientResponseModel>();

		public List<ApiLinkStatusClientResponseModel> LinkStatuses { get; private set; } = new List<ApiLinkStatusClientResponseModel>();

		public List<ApiMachineClientResponseModel> Machines { get; private set; } = new List<ApiMachineClientResponseModel>();

		public List<ApiOrganizationClientResponseModel> Organizations { get; private set; } = new List<ApiOrganizationClientResponseModel>();

		public List<ApiTeamClientResponseModel> Teams { get; private set; } = new List<ApiTeamClientResponseModel>();

		public List<ApiVersionInfoClientResponseModel> VersionInfoes { get; private set; } = new List<ApiVersionInfoClientResponseModel>();

		public void AddChainStatus(ApiChainStatusClientResponseModel item)
		{
			if (!this.ChainStatuses.Any(x => x.Id == item.Id))
			{
				this.ChainStatuses.Add(item);
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
			if (!this.LinkStatuses.Any(x => x.Id == item.Id))
			{
				this.LinkStatuses.Add(item);
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

		public void AddVersionInfo(ApiVersionInfoClientResponseModel item)
		{
			if (!this.VersionInfoes.Any(x => x.Version == item.Version))
			{
				this.VersionInfoes.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>73208e08b34b688f3d3bcadcbb9e8cc6</Hash>
</Codenesium>*/