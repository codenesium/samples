using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Client
{
	public abstract class AbstractApiClient
	{
		private HttpClient client;

		protected string ApiUrl { get; set; }

		protected string ApiVersion { get; set; }

		public AbstractApiClient(HttpClient client)
		{
			this.client = client;
		}

		public AbstractApiClient(string apiUri, string apiVersion)
		{
			if (string.IsNullOrWhiteSpace(apiUri))
			{
				throw new ArgumentException("apiUrl is not set");
			}
			if (apiUri[apiUri.Length - 1] != '/')
			{
				throw new ArgumentException("The apiUrl must end in a / for httpClient to work correctly");
			}
			if (string.IsNullOrWhiteSpace(apiVersion))
			{
				throw new ArgumentException("apiVersion is not set");
			}

			this.ApiUrl = apiUri;
			this.ApiVersion = apiVersion;
			this.client = new HttpClient();

			this.client.BaseAddress = new Uri(apiUri);

			this.client.DefaultRequestHeaders.Accept.Clear();
			this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			this.client.DefaultRequestHeaders.Add("api-version", this.ApiVersion);
		}

		public virtual async Task<ApiChainResponseModel> ChainCreateAsync(ApiChainRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Chains", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiChainResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChainResponseModel> ChainUpdateAsync(int id, ApiChainRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Chains/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiChainResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ChainDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Chains/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiChainResponseModel> ChainGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiChainResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainResponseModel>> ChainAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainResponseModel>> ChainBulkInsertAsync(List<ApiChainRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Chains/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChainResponseModel> GetChainGetExternalId(Guid externalId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/getExternalId/{externalId}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiChainResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChainStatusResponseModel> ChainStatusCreateAsync(ApiChainStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ChainStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiChainStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChainStatusResponseModel> ChainStatusUpdateAsync(int id, ApiChainStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ChainStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiChainStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ChainStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ChainStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiChainStatusResponseModel> ChainStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiChainStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainStatusResponseModel>> ChainStatusAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiChainStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainStatusResponseModel>> ChainStatusBulkInsertAsync(List<ApiChainStatusRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ChainStatus/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiChainStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChainStatusResponseModel> GetChainStatusGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiChainStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiClaspResponseModel> ClaspCreateAsync(ApiClaspRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clasps", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiClaspResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiClaspResponseModel> ClaspUpdateAsync(int id, ApiClaspRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Clasps/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiClaspResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ClaspDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Clasps/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiClaspResponseModel> ClaspGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clasps/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiClaspResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClaspResponseModel>> ClaspAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clasps?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiClaspResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClaspResponseModel>> ClaspBulkInsertAsync(List<ApiClaspRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clasps/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiClaspResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkResponseModel> LinkCreateAsync(ApiLinkRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Links", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLinkResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkResponseModel> LinkUpdateAsync(int id, ApiLinkRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Links/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLinkResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LinkDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Links/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiLinkResponseModel> LinkGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLinkResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkResponseModel>> LinkAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkResponseModel>> LinkBulkInsertAsync(List<ApiLinkRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Links/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkResponseModel> GetLinkGetExternalId(Guid externalId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/getExternalId/{externalId}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLinkResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkResponseModel>> GetLinkGetChainId(int chainId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/getChainId/{chainId}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkLogResponseModel> LinkLogCreateAsync(ApiLinkLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkLogs", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLinkLogResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkLogResponseModel> LinkLogUpdateAsync(int id, ApiLinkLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkLogs/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLinkLogResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LinkLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiLinkLogResponseModel> LinkLogGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLinkLogResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkLogResponseModel>> LinkLogAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkLogs?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkLogResponseModel>> LinkLogBulkInsertAsync(List<ApiLinkLogRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkLogs/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkStatusResponseModel> LinkStatusCreateAsync(ApiLinkStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLinkStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkStatusResponseModel> LinkStatusUpdateAsync(int id, ApiLinkStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLinkStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LinkStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiLinkStatusResponseModel> LinkStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLinkStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkStatusResponseModel>> LinkStatusAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiLinkStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkStatusResponseModel>> LinkStatusBulkInsertAsync(List<ApiLinkStatusRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkStatus/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiLinkStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkStatusResponseModel> GetLinkStatusGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLinkStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachineResponseModel> MachineCreateAsync(ApiMachineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachineResponseModel> MachineUpdateAsync(int id, ApiMachineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Machines/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task MachineDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Machines/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiMachineResponseModel> MachineGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineResponseModel>> MachineAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineResponseModel>> MachineBulkInsertAsync(List<ApiMachineRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachineResponseModel> GetMachineGetMachineGuid(Guid machineGuid)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/getMachineGuid/{machineGuid}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachineRefTeamResponseModel> MachineRefTeamCreateAsync(ApiMachineRefTeamRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachineRefTeams", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiMachineRefTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachineRefTeamResponseModel> MachineRefTeamUpdateAsync(int id, ApiMachineRefTeamRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/MachineRefTeams/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiMachineRefTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task MachineRefTeamDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/MachineRefTeams/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiMachineRefTeamResponseModel> MachineRefTeamGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachineRefTeams/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiMachineRefTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeamAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachineRefTeams?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiMachineRefTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeamBulkInsertAsync(List<ApiMachineRefTeamRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachineRefTeams/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiMachineRefTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiOrganizationResponseModel> OrganizationCreateAsync(ApiOrganizationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Organizations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiOrganizationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiOrganizationResponseModel> OrganizationUpdateAsync(int id, ApiOrganizationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Organizations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiOrganizationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task OrganizationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Organizations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiOrganizationResponseModel> OrganizationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiOrganizationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiOrganizationResponseModel>> OrganizationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiOrganizationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiOrganizationResponseModel>> OrganizationBulkInsertAsync(List<ApiOrganizationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Organizations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiOrganizationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiOrganizationResponseModel> GetOrganizationGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiOrganizationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeamResponseModel> TeamCreateAsync(ApiTeamRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeamResponseModel> TeamUpdateAsync(int id, ApiTeamRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Teams/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task TeamDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Teams/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiTeamResponseModel> TeamGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeamResponseModel>> TeamAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeamResponseModel>> TeamBulkInsertAsync(List<ApiTeamRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeamResponseModel> GetTeamGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVersionInfoResponseModel> VersionInfoCreateAsync(ApiVersionInfoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVersionInfoResponseModel> VersionInfoUpdateAsync(long id, ApiVersionInfoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/VersionInfoes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task VersionInfoDeleteAsync(long id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/VersionInfoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiVersionInfoResponseModel> VersionInfoGetAsync(long id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVersionInfoResponseModel>> VersionInfoAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVersionInfoResponseModel>> VersionInfoBulkInsertAsync(List<ApiVersionInfoRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVersionInfoResponseModel> GetVersionInfoGetVersion(long version)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes/getVersion/{version}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>4984fa6cfda55f3e97f6ad79f989717b</Hash>
</Codenesium>*/