using Codenesium.DataConversionExtensions;
using NebulaNS.Api.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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

		public AbstractApiClient(string apiUrl, string apiVersion)
		{
			if (string.IsNullOrWhiteSpace(apiUrl))
			{
				throw new ArgumentException("apiUrl is not set");
			}

			if (string.IsNullOrWhiteSpace(apiVersion))
			{
				throw new ArgumentException("apiVersion is not set");
			}

			if (!apiUrl.EndsWith("/"))
			{
				apiUrl += "/";
			}

			this.ApiUrl = apiUrl;
			this.ApiVersion = apiVersion;
			this.client = new HttpClient();
			this.client.BaseAddress = new Uri(apiUrl);
			this.client.DefaultRequestHeaders.Accept.Clear();
			this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			this.client.DefaultRequestHeaders.Add("api-version", this.ApiVersion);
		}

		public void SetBearerToken(string token)
		{
			this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}

		public virtual async Task<List<ApiChainResponseModel>> ChainBulkInsertAsync(List<ApiChainRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Chains/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiChainResponseModel>> ChainCreateAsync(ApiChainRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Chains", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiChainResponseModel>> ChainUpdateAsync(int id, ApiChainRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Chains/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ChainDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Chains/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChainResponseModel> ChainGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiChainResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainResponseModel>> ChainAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChainResponseModel> ByChainByExternalId(Guid externalId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/byExternalId/{externalId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiChainResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkResponseModel>> LinksByChainId(int chainId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/LinksByChainId/{chainId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainStatusResponseModel>> ChainStatusBulkInsertAsync(List<ApiChainStatusRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ChainStatuses/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChainStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiChainStatusResponseModel>> ChainStatusCreateAsync(ApiChainStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ChainStatuses", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiChainStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiChainStatusResponseModel>> ChainStatusUpdateAsync(int id, ApiChainStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ChainStatuses/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiChainStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ChainStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ChainStatuses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChainStatusResponseModel> ChainStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatuses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiChainStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainStatusResponseModel>> ChainStatusAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatuses?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChainStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChainStatusResponseModel> ByChainStatusByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatuses/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiChainStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainResponseModel>> ChainsByChainStatusId(int chainStatusId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatuses/ChainsByChainStatusId/{chainStatusId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkResponseModel>> LinkBulkInsertAsync(List<ApiLinkRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Links/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLinkResponseModel>> LinkCreateAsync(ApiLinkRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Links", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLinkResponseModel>> LinkUpdateAsync(int id, ApiLinkRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Links/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LinkDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Links/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkResponseModel> LinkGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLinkResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkResponseModel>> LinkAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkResponseModel> ByLinkByExternalId(Guid externalId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/byExternalId/{externalId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLinkResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkResponseModel>> ByLinkByChainId(int chainId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/byChainId/{chainId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkLogResponseModel>> LinkLogsByLinkId(int linkId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/LinkLogsByLinkId/{linkId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkLogResponseModel>> LinkLogBulkInsertAsync(List<ApiLinkLogRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkLogs/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLinkLogResponseModel>> LinkLogCreateAsync(ApiLinkLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkLogs", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLinkLogResponseModel>> LinkLogUpdateAsync(int id, ApiLinkLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkLogs/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LinkLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkLogs/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkLogResponseModel> LinkLogGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkLogs/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLinkLogResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkLogResponseModel>> LinkLogAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkLogs?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkStatusResponseModel>> LinkStatusBulkInsertAsync(List<ApiLinkStatusRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkStatuses/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLinkStatusResponseModel>> LinkStatusCreateAsync(ApiLinkStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkStatuses", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLinkStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLinkStatusResponseModel>> LinkStatusUpdateAsync(int id, ApiLinkStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkStatuses/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLinkStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LinkStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkStatuses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkStatusResponseModel> LinkStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatuses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLinkStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkStatusResponseModel>> LinkStatusAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatuses?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkStatusResponseModel> ByLinkStatusByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatuses/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLinkStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkResponseModel>> LinksByLinkStatusId(int linkStatusId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatuses/LinksByLinkStatusId/{linkStatusId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineResponseModel>> MachineBulkInsertAsync(List<ApiMachineRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiMachineResponseModel>> MachineCreateAsync(ApiMachineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiMachineResponseModel>> MachineUpdateAsync(int id, ApiMachineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Machines/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> MachineDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Machines/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachineResponseModel> MachineGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineResponseModel>> MachineAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachineResponseModel> ByMachineByMachineGuid(Guid machineGuid)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/byMachineGuid/{machineGuid}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkResponseModel>> LinksByAssignedMachineId(int assignedMachineId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/LinksByAssignedMachineId/{assignedMachineId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiOrganizationResponseModel>> OrganizationBulkInsertAsync(List<ApiOrganizationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Organizations/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiOrganizationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiOrganizationResponseModel>> OrganizationCreateAsync(ApiOrganizationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Organizations", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiOrganizationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiOrganizationResponseModel>> OrganizationUpdateAsync(int id, ApiOrganizationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Organizations/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiOrganizationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> OrganizationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Organizations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiOrganizationResponseModel> OrganizationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiOrganizationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiOrganizationResponseModel>> OrganizationAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiOrganizationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiOrganizationResponseModel> ByOrganizationByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiOrganizationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeamResponseModel>> TeamsByOrganizationId(int organizationId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations/TeamsByOrganizationId/{organizationId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeamResponseModel>> TeamBulkInsertAsync(List<ApiTeamRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTeamResponseModel>> TeamCreateAsync(ApiTeamRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTeamResponseModel>> TeamUpdateAsync(int id, ApiTeamRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Teams/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TeamDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Teams/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeamResponseModel> TeamGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeamResponseModel>> TeamAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeamResponseModel> ByTeamByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainResponseModel>> ChainsByTeamId(int teamId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/ChainsByTeamId/{teamId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVersionInfoResponseModel>> VersionInfoBulkInsertAsync(List<ApiVersionInfoRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiVersionInfoResponseModel>> VersionInfoCreateAsync(ApiVersionInfoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiVersionInfoResponseModel>> VersionInfoUpdateAsync(long id, ApiVersionInfoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/VersionInfoes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> VersionInfoDeleteAsync(long id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/VersionInfoes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVersionInfoResponseModel> VersionInfoGetAsync(long id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVersionInfoResponseModel>> VersionInfoAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>0d29c59ec21c10f78755e62eeb103888</Hash>
</Codenesium>*/