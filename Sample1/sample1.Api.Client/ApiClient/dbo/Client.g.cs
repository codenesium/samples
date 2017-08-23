using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using sample1NS.Api.Contracts;
namespace sample1NS.Api.Client
{
	public abstract class AbstractApiClient
	{
		public HttpClient _client;
		protected string ApiUrl { get; set; }
		public AbstractApiClient(string apiUri)
		{
			if (String.IsNullOrWhiteSpace(apiUri))
			{
				throw new ArgumentException("apiUrl is not set");
			}
			if (apiUri[apiUri.Length - 1] != '/')
			{
				throw new ArgumentException("The apiUrl must end in a / for httpClient to work correctly");
			}

			this.ApiUrl = apiUri;
			this._client = new HttpClient();

			this._client.BaseAddress = new Uri(apiUri);

			this._client.DefaultRequestHeaders.Accept.Clear();
			this._client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public virtual async Task<List<POCOChain>>ChainSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Chains?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Chains;
		}

		public virtual async Task<List<POCOChain>> ChainGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Chains/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Chains;
		}

		public virtual async Task<POCOChain> ChainGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Chains/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Chains.FirstOrDefault();
		}

		public virtual async Task<List<POCOChain>> ChainGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Chains?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Chains;
		}

		public virtual async Task ChainDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Chains/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ChainUpdateAsync(int id,ChainModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Chains/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ChainCreateAsync(ChainModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Chains", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ChainCreateManyAsync(List<ChainModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Chains/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOChainStatus>>ChainStatusSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ChainStatus?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ChainStatus;
		}

		public virtual async Task<List<POCOChainStatus>> ChainStatusGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ChainStatus/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ChainStatus;
		}

		public virtual async Task<POCOChainStatus> ChainStatusGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ChainStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ChainStatus.FirstOrDefault();
		}

		public virtual async Task<List<POCOChainStatus>> ChainStatusGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ChainStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ChainStatus;
		}

		public virtual async Task ChainStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ChainStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ChainStatusUpdateAsync(int id,ChainStatusModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ChainStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ChainStatusCreateAsync(ChainStatusModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ChainStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ChainStatusCreateManyAsync(List<ChainStatusModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ChainStatus/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOClasp>>ClaspSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Clasps?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Clasps;
		}

		public virtual async Task<List<POCOClasp>> ClaspGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Clasps/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Clasps;
		}

		public virtual async Task<POCOClasp> ClaspGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Clasps/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Clasps.FirstOrDefault();
		}

		public virtual async Task<List<POCOClasp>> ClaspGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Clasps?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Clasps;
		}

		public virtual async Task ClaspDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Clasps/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ClaspUpdateAsync(int id,ClaspModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Clasps/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ClaspCreateAsync(ClaspModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Clasps", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ClaspCreateManyAsync(List<ClaspModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Clasps/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOLink>>LinkSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Links?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Links;
		}

		public virtual async Task<List<POCOLink>> LinkGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Links/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Links;
		}

		public virtual async Task<POCOLink> LinkGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Links/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Links.FirstOrDefault();
		}

		public virtual async Task<List<POCOLink>> LinkGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Links?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Links;
		}

		public virtual async Task LinkDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Links/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task LinkUpdateAsync(int id,LinkModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Links/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> LinkCreateAsync(LinkModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Links", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task LinkCreateManyAsync(List<LinkModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Links/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOLinkLog>>LinkLogSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/LinkLogs?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).LinkLogs;
		}

		public virtual async Task<List<POCOLinkLog>> LinkLogGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/LinkLogs/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).LinkLogs;
		}

		public virtual async Task<POCOLinkLog> LinkLogGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/LinkLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).LinkLogs.FirstOrDefault();
		}

		public virtual async Task<List<POCOLinkLog>> LinkLogGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/LinkLogs?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).LinkLogs;
		}

		public virtual async Task LinkLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/LinkLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task LinkLogUpdateAsync(int id,LinkLogModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/LinkLogs/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> LinkLogCreateAsync(LinkLogModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/LinkLogs", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task LinkLogCreateManyAsync(List<LinkLogModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/LinkLogs/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOLinkStatus>>LinkStatusSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/LinkStatus?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).LinkStatus;
		}

		public virtual async Task<List<POCOLinkStatus>> LinkStatusGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/LinkStatus/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).LinkStatus;
		}

		public virtual async Task<POCOLinkStatus> LinkStatusGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/LinkStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).LinkStatus.FirstOrDefault();
		}

		public virtual async Task<List<POCOLinkStatus>> LinkStatusGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/LinkStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).LinkStatus;
		}

		public virtual async Task LinkStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/LinkStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task LinkStatusUpdateAsync(int id,LinkStatusModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/LinkStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> LinkStatusCreateAsync(LinkStatusModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/LinkStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task LinkStatusCreateManyAsync(List<LinkStatusModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/LinkStatus/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOMachine>>MachineSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Machines?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Machines;
		}

		public virtual async Task<List<POCOMachine>> MachineGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Machines/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Machines;
		}

		public virtual async Task<POCOMachine> MachineGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Machines/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Machines.FirstOrDefault();
		}

		public virtual async Task<List<POCOMachine>> MachineGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Machines?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Machines;
		}

		public virtual async Task MachineDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Machines/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task MachineUpdateAsync(int id,MachineModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Machines/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> MachineCreateAsync(MachineModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Machines", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task MachineCreateManyAsync(List<MachineModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Machines/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOMachineRefTeam>>MachineRefTeamSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/MachineRefTeams?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).MachineRefTeams;
		}

		public virtual async Task<List<POCOMachineRefTeam>> MachineRefTeamGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/MachineRefTeams/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).MachineRefTeams;
		}

		public virtual async Task<POCOMachineRefTeam> MachineRefTeamGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/MachineRefTeams/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).MachineRefTeams.FirstOrDefault();
		}

		public virtual async Task<List<POCOMachineRefTeam>> MachineRefTeamGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/MachineRefTeams?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).MachineRefTeams;
		}

		public virtual async Task MachineRefTeamDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/MachineRefTeams/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task MachineRefTeamUpdateAsync(int id,MachineRefTeamModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/MachineRefTeams/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> MachineRefTeamCreateAsync(MachineRefTeamModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/MachineRefTeams", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task MachineRefTeamCreateManyAsync(List<MachineRefTeamModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/MachineRefTeams/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOOrganization>>OrganizationSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Organizations?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Organizations;
		}

		public virtual async Task<List<POCOOrganization>> OrganizationGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Organizations/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Organizations;
		}

		public virtual async Task<POCOOrganization> OrganizationGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Organizations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Organizations.FirstOrDefault();
		}

		public virtual async Task<List<POCOOrganization>> OrganizationGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Organizations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Organizations;
		}

		public virtual async Task OrganizationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Organizations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task OrganizationUpdateAsync(int id,OrganizationModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Organizations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> OrganizationCreateAsync(OrganizationModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Organizations", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task OrganizationCreateManyAsync(List<OrganizationModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Organizations/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOTeam>>TeamSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Teams?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Teams;
		}

		public virtual async Task<List<POCOTeam>> TeamGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Teams/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Teams;
		}

		public virtual async Task<POCOTeam> TeamGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Teams/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Teams.FirstOrDefault();
		}

		public virtual async Task<List<POCOTeam>> TeamGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Teams?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Teams;
		}

		public virtual async Task TeamDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Teams/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task TeamUpdateAsync(int id,TeamModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Teams/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> TeamCreateAsync(TeamModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Teams", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task TeamCreateManyAsync(List<TeamModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Teams/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}
	}
}

/*<Codenesium>
    <Hash>8ec287a7e8700d76c0ffceb18e6cc1f5</Hash>
</Codenesium>*/