using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Client
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

		public virtual async Task<CreateResponse<ApiAccountResponseModel>> AccountCreateAsync(ApiAccountRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Accounts", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiAccountResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiAccountResponseModel>> AccountUpdateAsync(string id, ApiAccountRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Accounts/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiAccountResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> AccountDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Accounts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAccountResponseModel> AccountGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Accounts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiAccountResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAccountResponseModel>> AccountAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Accounts?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAccountResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAccountResponseModel>> AccountBulkInsertAsync(List<ApiAccountRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Accounts/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAccountResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAccountResponseModel> GetAccountByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Accounts/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiAccountResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiActionTemplateResponseModel>> ActionTemplateCreateAsync(ApiActionTemplateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ActionTemplates", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiActionTemplateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiActionTemplateResponseModel>> ActionTemplateUpdateAsync(string id, ApiActionTemplateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ActionTemplates/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiActionTemplateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ActionTemplateDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ActionTemplates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiActionTemplateResponseModel> ActionTemplateGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiActionTemplateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiActionTemplateResponseModel>> ActionTemplateAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplates?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiActionTemplateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiActionTemplateResponseModel>> ActionTemplateBulkInsertAsync(List<ApiActionTemplateRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ActionTemplates/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiActionTemplateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiActionTemplateResponseModel> GetActionTemplateByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplates/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiActionTemplateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiActionTemplateVersionResponseModel>> ActionTemplateVersionCreateAsync(ApiActionTemplateVersionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ActionTemplateVersions", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiActionTemplateVersionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiActionTemplateVersionResponseModel>> ActionTemplateVersionUpdateAsync(string id, ApiActionTemplateVersionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ActionTemplateVersions/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiActionTemplateVersionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ActionTemplateVersionDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ActionTemplateVersions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiActionTemplateVersionResponseModel> ActionTemplateVersionGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplateVersions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiActionTemplateVersionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiActionTemplateVersionResponseModel>> ActionTemplateVersionAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplateVersions?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiActionTemplateVersionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiActionTemplateVersionResponseModel>> ActionTemplateVersionBulkInsertAsync(List<ApiActionTemplateVersionRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ActionTemplateVersions/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiActionTemplateVersionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiActionTemplateVersionResponseModel> GetActionTemplateVersionByNameVersion(string name, int version)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplateVersions/byNameVersion/{name}/{version}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiActionTemplateVersionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiActionTemplateVersionResponseModel>> GetActionTemplateVersionByLatestActionTemplateId(string latestActionTemplateId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplateVersions/byLatestActionTemplateId/{latestActionTemplateId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiActionTemplateVersionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiApiKeyResponseModel>> ApiKeyCreateAsync(ApiApiKeyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ApiKeys", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiApiKeyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiApiKeyResponseModel>> ApiKeyUpdateAsync(string id, ApiApiKeyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ApiKeys/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiApiKeyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ApiKeyDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ApiKeys/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiApiKeyResponseModel> ApiKeyGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ApiKeys/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiApiKeyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiApiKeyResponseModel>> ApiKeyAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ApiKeys?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiApiKeyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiApiKeyResponseModel>> ApiKeyBulkInsertAsync(List<ApiApiKeyRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ApiKeys/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiApiKeyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiApiKeyResponseModel> GetApiKeyByApiKeyHashed(string apiKeyHashed)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ApiKeys/byApiKeyHashed/{apiKeyHashed}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiApiKeyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiArtifactResponseModel>> ArtifactCreateAsync(ApiArtifactRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Artifacts", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiArtifactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiArtifactResponseModel>> ArtifactUpdateAsync(string id, ApiArtifactRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Artifacts/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiArtifactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ArtifactDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Artifacts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiArtifactResponseModel> ArtifactGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Artifacts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiArtifactResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiArtifactResponseModel>> ArtifactAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Artifacts?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiArtifactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiArtifactResponseModel>> ArtifactBulkInsertAsync(List<ApiArtifactRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Artifacts/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiArtifactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiArtifactResponseModel>> GetArtifactByTenantId(string tenantId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Artifacts/byTenantId/{tenantId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiArtifactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCertificateResponseModel>> CertificateCreateAsync(ApiCertificateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Certificates", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCertificateResponseModel>> CertificateUpdateAsync(string id, ApiCertificateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Certificates/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CertificateDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Certificates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCertificateResponseModel> CertificateGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Certificates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCertificateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCertificateResponseModel>> CertificateAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Certificates?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCertificateResponseModel>> CertificateBulkInsertAsync(List<ApiCertificateRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Certificates/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCertificateResponseModel>> GetCertificateByCreated(DateTimeOffset created)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Certificates/byCreated/{created}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCertificateResponseModel>> GetCertificateByDataVersion(byte[] dataVersion)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Certificates/byDataVersion/{dataVersion}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCertificateResponseModel>> GetCertificateByNotAfter(DateTimeOffset notAfter)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Certificates/byNotAfter/{notAfter}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCertificateResponseModel>> GetCertificateByThumbprint(string thumbprint)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Certificates/byThumbprint/{thumbprint}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiChannelResponseModel>> ChannelCreateAsync(ApiChannelRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Channels", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiChannelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiChannelResponseModel>> ChannelUpdateAsync(string id, ApiChannelRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Channels/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiChannelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ChannelDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Channels/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChannelResponseModel> ChannelGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Channels/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiChannelResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChannelResponseModel>> ChannelAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Channels?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChannelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChannelResponseModel>> ChannelBulkInsertAsync(List<ApiChannelRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Channels/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChannelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChannelResponseModel> GetChannelByNameProjectId(string name, string projectId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Channels/byNameProjectId/{name}/{projectId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiChannelResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChannelResponseModel>> GetChannelByDataVersion(byte[] dataVersion)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Channels/byDataVersion/{dataVersion}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChannelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChannelResponseModel>> GetChannelByProjectId(string projectId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Channels/byProjectId/{projectId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChannelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCommunityActionTemplateResponseModel>> CommunityActionTemplateCreateAsync(ApiCommunityActionTemplateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CommunityActionTemplates", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCommunityActionTemplateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCommunityActionTemplateResponseModel>> CommunityActionTemplateUpdateAsync(string id, ApiCommunityActionTemplateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CommunityActionTemplates/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCommunityActionTemplateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CommunityActionTemplateDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CommunityActionTemplates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCommunityActionTemplateResponseModel> CommunityActionTemplateGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CommunityActionTemplates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCommunityActionTemplateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCommunityActionTemplateResponseModel>> CommunityActionTemplateAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CommunityActionTemplates?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCommunityActionTemplateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCommunityActionTemplateResponseModel>> CommunityActionTemplateBulkInsertAsync(List<ApiCommunityActionTemplateRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CommunityActionTemplates/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCommunityActionTemplateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCommunityActionTemplateResponseModel> GetCommunityActionTemplateByExternalId(Guid externalId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CommunityActionTemplates/byExternalId/{externalId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCommunityActionTemplateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCommunityActionTemplateResponseModel> GetCommunityActionTemplateByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CommunityActionTemplates/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCommunityActionTemplateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiConfigurationResponseModel>> ConfigurationCreateAsync(ApiConfigurationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Configurations", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiConfigurationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiConfigurationResponseModel>> ConfigurationUpdateAsync(string id, ApiConfigurationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Configurations/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiConfigurationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ConfigurationDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Configurations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiConfigurationResponseModel> ConfigurationGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Configurations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiConfigurationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiConfigurationResponseModel>> ConfigurationAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Configurations?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiConfigurationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiConfigurationResponseModel>> ConfigurationBulkInsertAsync(List<ApiConfigurationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Configurations/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiConfigurationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDashboardConfigurationResponseModel>> DashboardConfigurationCreateAsync(ApiDashboardConfigurationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DashboardConfigurations", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiDashboardConfigurationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDashboardConfigurationResponseModel>> DashboardConfigurationUpdateAsync(string id, ApiDashboardConfigurationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DashboardConfigurations/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiDashboardConfigurationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DashboardConfigurationDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DashboardConfigurations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDashboardConfigurationResponseModel> DashboardConfigurationGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DashboardConfigurations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDashboardConfigurationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDashboardConfigurationResponseModel>> DashboardConfigurationAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DashboardConfigurations?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDashboardConfigurationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDashboardConfigurationResponseModel>> DashboardConfigurationBulkInsertAsync(List<ApiDashboardConfigurationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DashboardConfigurations/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDashboardConfigurationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDeploymentResponseModel>> DeploymentCreateAsync(ApiDeploymentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Deployments", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiDeploymentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDeploymentResponseModel>> DeploymentUpdateAsync(string id, ApiDeploymentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Deployments/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiDeploymentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DeploymentDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Deployments/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDeploymentResponseModel> DeploymentGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Deployments/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDeploymentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentResponseModel>> DeploymentAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Deployments?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentResponseModel>> DeploymentBulkInsertAsync(List<ApiDeploymentRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Deployments/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentResponseModel>> GetDeploymentByChannelId(string channelId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Deployments/byChannelId/{channelId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentResponseModel>> GetDeploymentByIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTimeOffset created, string releaseId, string taskId, string environmentId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Deployments/byIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId/{id}/{projectId}/{projectGroupId}/{name}/{created}/{releaseId}/{taskId}/{environmentId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentResponseModel>> GetDeploymentByTenantId(string tenantId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Deployments/byTenantId/{tenantId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentRelatedMachineResponseModel>> DeploymentRelatedMachines(string deploymentId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Deployments/DeploymentRelatedMachines/{deploymentId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentRelatedMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDeploymentEnvironmentResponseModel>> DeploymentEnvironmentCreateAsync(ApiDeploymentEnvironmentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentEnvironments", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiDeploymentEnvironmentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDeploymentEnvironmentResponseModel>> DeploymentEnvironmentUpdateAsync(string id, ApiDeploymentEnvironmentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DeploymentEnvironments/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiDeploymentEnvironmentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DeploymentEnvironmentDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DeploymentEnvironments/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDeploymentEnvironmentResponseModel> DeploymentEnvironmentGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentEnvironments/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDeploymentEnvironmentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentEnvironmentResponseModel>> DeploymentEnvironmentAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentEnvironments?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentEnvironmentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentEnvironmentResponseModel>> DeploymentEnvironmentBulkInsertAsync(List<ApiDeploymentEnvironmentRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentEnvironments/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentEnvironmentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDeploymentEnvironmentResponseModel> GetDeploymentEnvironmentByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentEnvironments/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDeploymentEnvironmentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentEnvironmentResponseModel>> GetDeploymentEnvironmentByDataVersion(byte[] dataVersion)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentEnvironments/byDataVersion/{dataVersion}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentEnvironmentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDeploymentHistoryResponseModel>> DeploymentHistoryCreateAsync(ApiDeploymentHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentHistories", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiDeploymentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDeploymentHistoryResponseModel>> DeploymentHistoryUpdateAsync(string id, ApiDeploymentHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DeploymentHistories/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiDeploymentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DeploymentHistoryDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DeploymentHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDeploymentHistoryResponseModel> DeploymentHistoryGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDeploymentHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentHistoryResponseModel>> DeploymentHistoryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentHistoryResponseModel>> DeploymentHistoryBulkInsertAsync(List<ApiDeploymentHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentHistories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentHistoryResponseModel>> GetDeploymentHistoryByCreated(DateTimeOffset created)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentHistories/byCreated/{created}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDeploymentProcessResponseModel>> DeploymentProcessCreateAsync(ApiDeploymentProcessRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentProcesses", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiDeploymentProcessResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDeploymentProcessResponseModel>> DeploymentProcessUpdateAsync(string id, ApiDeploymentProcessRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DeploymentProcesses/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiDeploymentProcessResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DeploymentProcessDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DeploymentProcesses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDeploymentProcessResponseModel> DeploymentProcessGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentProcesses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDeploymentProcessResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentProcessResponseModel>> DeploymentProcessAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentProcesses?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentProcessResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentProcessResponseModel>> DeploymentProcessBulkInsertAsync(List<ApiDeploymentProcessRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentProcesses/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentProcessResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDeploymentRelatedMachineResponseModel>> DeploymentRelatedMachineCreateAsync(ApiDeploymentRelatedMachineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentRelatedMachines", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiDeploymentRelatedMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDeploymentRelatedMachineResponseModel>> DeploymentRelatedMachineUpdateAsync(int id, ApiDeploymentRelatedMachineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DeploymentRelatedMachines/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiDeploymentRelatedMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DeploymentRelatedMachineDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DeploymentRelatedMachines/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDeploymentRelatedMachineResponseModel> DeploymentRelatedMachineGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentRelatedMachines/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDeploymentRelatedMachineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentRelatedMachineResponseModel>> DeploymentRelatedMachineAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentRelatedMachines?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentRelatedMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentRelatedMachineResponseModel>> DeploymentRelatedMachineBulkInsertAsync(List<ApiDeploymentRelatedMachineRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentRelatedMachines/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentRelatedMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentRelatedMachineResponseModel>> GetDeploymentRelatedMachineByDeploymentId(string deploymentId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentRelatedMachines/byDeploymentId/{deploymentId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentRelatedMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeploymentRelatedMachineResponseModel>> GetDeploymentRelatedMachineByMachineId(string machineId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentRelatedMachines/byMachineId/{machineId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeploymentRelatedMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiEventResponseModel>> EventCreateAsync(ApiEventRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Events", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiEventResponseModel>> EventUpdateAsync(string id, ApiEventRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Events/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> EventDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Events/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEventResponseModel> EventGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiEventResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventResponseModel>> EventAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventResponseModel>> EventBulkInsertAsync(List<ApiEventRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Events/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventResponseModel>> GetEventByAutoId(long autoId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/byAutoId/{autoId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventResponseModel>> GetEventByIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTimeOffset occurred, string category, long autoId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/byIdRelatedDocumentIdsOccurredCategoryAutoId/{id}/{relatedDocumentIds}/{occurred}/{category}/{autoId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventResponseModel>> GetEventByIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTimeOffset occurred, string tenantId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/byIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId/{id}/{relatedDocumentIds}/{projectId}/{environmentId}/{category}/{userId}/{occurred}/{tenantId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventResponseModel>> GetEventByIdOccurred(string id, DateTimeOffset occurred)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/byIdOccurred/{id}/{occurred}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventRelatedDocumentResponseModel>> EventRelatedDocuments(string eventId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/EventRelatedDocuments/{eventId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventRelatedDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiEventRelatedDocumentResponseModel>> EventRelatedDocumentCreateAsync(ApiEventRelatedDocumentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EventRelatedDocuments", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiEventRelatedDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiEventRelatedDocumentResponseModel>> EventRelatedDocumentUpdateAsync(int id, ApiEventRelatedDocumentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EventRelatedDocuments/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiEventRelatedDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> EventRelatedDocumentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EventRelatedDocuments/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEventRelatedDocumentResponseModel> EventRelatedDocumentGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventRelatedDocuments/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiEventRelatedDocumentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventRelatedDocumentResponseModel>> EventRelatedDocumentAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventRelatedDocuments?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventRelatedDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventRelatedDocumentResponseModel>> EventRelatedDocumentBulkInsertAsync(List<ApiEventRelatedDocumentRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EventRelatedDocuments/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventRelatedDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventRelatedDocumentResponseModel>> GetEventRelatedDocumentByEventId(string eventId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventRelatedDocuments/byEventId/{eventId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventRelatedDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventRelatedDocumentResponseModel>> GetEventRelatedDocumentByEventIdRelatedDocumentId(string eventId, string relatedDocumentId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventRelatedDocuments/byEventIdRelatedDocumentId/{eventId}/{relatedDocumentId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventRelatedDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiExtensionConfigurationResponseModel>> ExtensionConfigurationCreateAsync(ApiExtensionConfigurationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ExtensionConfigurations", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiExtensionConfigurationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiExtensionConfigurationResponseModel>> ExtensionConfigurationUpdateAsync(string id, ApiExtensionConfigurationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ExtensionConfigurations/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiExtensionConfigurationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ExtensionConfigurationDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ExtensionConfigurations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiExtensionConfigurationResponseModel> ExtensionConfigurationGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ExtensionConfigurations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiExtensionConfigurationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiExtensionConfigurationResponseModel>> ExtensionConfigurationAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ExtensionConfigurations?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiExtensionConfigurationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiExtensionConfigurationResponseModel>> ExtensionConfigurationBulkInsertAsync(List<ApiExtensionConfigurationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ExtensionConfigurations/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiExtensionConfigurationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiFeedResponseModel>> FeedCreateAsync(ApiFeedRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Feeds", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiFeedResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiFeedResponseModel>> FeedUpdateAsync(string id, ApiFeedRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Feeds/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiFeedResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> FeedDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Feeds/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiFeedResponseModel> FeedGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Feeds/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiFeedResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiFeedResponseModel>> FeedAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Feeds?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiFeedResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiFeedResponseModel>> FeedBulkInsertAsync(List<ApiFeedRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Feeds/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiFeedResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiFeedResponseModel> GetFeedByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Feeds/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiFeedResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiInterruptionResponseModel>> InterruptionCreateAsync(ApiInterruptionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Interruptions", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiInterruptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiInterruptionResponseModel>> InterruptionUpdateAsync(string id, ApiInterruptionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Interruptions/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiInterruptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> InterruptionDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Interruptions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiInterruptionResponseModel> InterruptionGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Interruptions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiInterruptionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiInterruptionResponseModel>> InterruptionAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Interruptions?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiInterruptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiInterruptionResponseModel>> InterruptionBulkInsertAsync(List<ApiInterruptionRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Interruptions/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiInterruptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiInterruptionResponseModel>> GetInterruptionByTenantId(string tenantId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Interruptions/byTenantId/{tenantId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiInterruptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiInvitationResponseModel>> InvitationCreateAsync(ApiInvitationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Invitations", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiInvitationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiInvitationResponseModel>> InvitationUpdateAsync(string id, ApiInvitationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Invitations/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiInvitationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> InvitationDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Invitations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiInvitationResponseModel> InvitationGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Invitations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiInvitationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiInvitationResponseModel>> InvitationAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Invitations?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiInvitationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiInvitationResponseModel>> InvitationBulkInsertAsync(List<ApiInvitationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Invitations/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiInvitationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiKeyAllocationResponseModel>> KeyAllocationCreateAsync(ApiKeyAllocationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/KeyAllocations", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiKeyAllocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiKeyAllocationResponseModel>> KeyAllocationUpdateAsync(string id, ApiKeyAllocationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/KeyAllocations/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiKeyAllocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> KeyAllocationDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/KeyAllocations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiKeyAllocationResponseModel> KeyAllocationGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/KeyAllocations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiKeyAllocationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiKeyAllocationResponseModel>> KeyAllocationAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/KeyAllocations?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiKeyAllocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiKeyAllocationResponseModel>> KeyAllocationBulkInsertAsync(List<ApiKeyAllocationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/KeyAllocations/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiKeyAllocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLibraryVariableSetResponseModel>> LibraryVariableSetCreateAsync(ApiLibraryVariableSetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LibraryVariableSets", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLibraryVariableSetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLibraryVariableSetResponseModel>> LibraryVariableSetUpdateAsync(string id, ApiLibraryVariableSetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LibraryVariableSets/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLibraryVariableSetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LibraryVariableSetDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LibraryVariableSets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLibraryVariableSetResponseModel> LibraryVariableSetGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LibraryVariableSets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLibraryVariableSetResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLibraryVariableSetResponseModel>> LibraryVariableSetAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LibraryVariableSets?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLibraryVariableSetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLibraryVariableSetResponseModel>> LibraryVariableSetBulkInsertAsync(List<ApiLibraryVariableSetRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LibraryVariableSets/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLibraryVariableSetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLibraryVariableSetResponseModel> GetLibraryVariableSetByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LibraryVariableSets/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLibraryVariableSetResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLifecycleResponseModel>> LifecycleCreateAsync(ApiLifecycleRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Lifecycles", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLifecycleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLifecycleResponseModel>> LifecycleUpdateAsync(string id, ApiLifecycleRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Lifecycles/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLifecycleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LifecycleDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Lifecycles/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLifecycleResponseModel> LifecycleGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lifecycles/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLifecycleResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLifecycleResponseModel>> LifecycleAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lifecycles?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLifecycleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLifecycleResponseModel>> LifecycleBulkInsertAsync(List<ApiLifecycleRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Lifecycles/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLifecycleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLifecycleResponseModel> GetLifecycleByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lifecycles/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLifecycleResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLifecycleResponseModel>> GetLifecycleByDataVersion(byte[] dataVersion)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lifecycles/byDataVersion/{dataVersion}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLifecycleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiMachineResponseModel>> MachineCreateAsync(ApiMachineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiMachineResponseModel>> MachineUpdateAsync(string id, ApiMachineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Machines/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> MachineDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Machines/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachineResponseModel> MachineGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineResponseModel>> MachineAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineResponseModel>> MachineBulkInsertAsync(List<ApiMachineRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachineResponseModel> GetMachineByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineResponseModel>> GetMachineByMachinePolicyId(string machinePolicyId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/byMachinePolicyId/{machinePolicyId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiMachinePolicyResponseModel>> MachinePolicyCreateAsync(ApiMachinePolicyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachinePolicies", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiMachinePolicyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiMachinePolicyResponseModel>> MachinePolicyUpdateAsync(string id, ApiMachinePolicyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/MachinePolicies/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiMachinePolicyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> MachinePolicyDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/MachinePolicies/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachinePolicyResponseModel> MachinePolicyGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachinePolicies/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiMachinePolicyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachinePolicyResponseModel>> MachinePolicyAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachinePolicies?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMachinePolicyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachinePolicyResponseModel>> MachinePolicyBulkInsertAsync(List<ApiMachinePolicyRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachinePolicies/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMachinePolicyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachinePolicyResponseModel> GetMachinePolicyByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachinePolicies/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiMachinePolicyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiMutexResponseModel>> MutexCreateAsync(ApiMutexRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Mutexes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiMutexResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiMutexResponseModel>> MutexUpdateAsync(string id, ApiMutexRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Mutexes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiMutexResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> MutexDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Mutexes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMutexResponseModel> MutexGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Mutexes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiMutexResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMutexResponseModel>> MutexAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Mutexes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMutexResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMutexResponseModel>> MutexBulkInsertAsync(List<ApiMutexRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Mutexes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMutexResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiNuGetPackageResponseModel>> NuGetPackageCreateAsync(ApiNuGetPackageRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/NuGetPackages", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiNuGetPackageResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiNuGetPackageResponseModel>> NuGetPackageUpdateAsync(string id, ApiNuGetPackageRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/NuGetPackages/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiNuGetPackageResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> NuGetPackageDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/NuGetPackages/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiNuGetPackageResponseModel> NuGetPackageGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/NuGetPackages/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiNuGetPackageResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiNuGetPackageResponseModel>> NuGetPackageAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/NuGetPackages?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiNuGetPackageResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiNuGetPackageResponseModel>> NuGetPackageBulkInsertAsync(List<ApiNuGetPackageRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/NuGetPackages/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiNuGetPackageResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiOctopusServerNodeResponseModel>> OctopusServerNodeCreateAsync(ApiOctopusServerNodeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/OctopusServerNodes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiOctopusServerNodeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiOctopusServerNodeResponseModel>> OctopusServerNodeUpdateAsync(string id, ApiOctopusServerNodeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/OctopusServerNodes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiOctopusServerNodeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> OctopusServerNodeDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/OctopusServerNodes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiOctopusServerNodeResponseModel> OctopusServerNodeGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/OctopusServerNodes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiOctopusServerNodeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiOctopusServerNodeResponseModel>> OctopusServerNodeAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/OctopusServerNodes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiOctopusServerNodeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiOctopusServerNodeResponseModel>> OctopusServerNodeBulkInsertAsync(List<ApiOctopusServerNodeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/OctopusServerNodes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiOctopusServerNodeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProjectResponseModel>> ProjectCreateAsync(ApiProjectRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Projects", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProjectResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProjectResponseModel>> ProjectUpdateAsync(string id, ApiProjectRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Projects/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProjectResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProjectDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Projects/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProjectResponseModel> ProjectGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Projects/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProjectResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProjectResponseModel>> ProjectAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Projects?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProjectResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProjectResponseModel>> ProjectBulkInsertAsync(List<ApiProjectRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Projects/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProjectResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProjectResponseModel> GetProjectByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Projects/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProjectResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProjectResponseModel> GetProjectBySlug(string slug)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Projects/bySlug/{slug}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProjectResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProjectResponseModel>> GetProjectByDataVersion(byte[] dataVersion)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Projects/byDataVersion/{dataVersion}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProjectResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProjectResponseModel>> GetProjectByDiscreteChannelReleaseId(bool discreteChannelRelease, string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Projects/byDiscreteChannelReleaseId/{discreteChannelRelease}/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProjectResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProjectGroupResponseModel>> ProjectGroupCreateAsync(ApiProjectGroupRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProjectGroups", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProjectGroupResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProjectGroupResponseModel>> ProjectGroupUpdateAsync(string id, ApiProjectGroupRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProjectGroups/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProjectGroupResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProjectGroupDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProjectGroups/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProjectGroupResponseModel> ProjectGroupGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectGroups/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProjectGroupResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProjectGroupResponseModel>> ProjectGroupAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectGroups?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProjectGroupResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProjectGroupResponseModel>> ProjectGroupBulkInsertAsync(List<ApiProjectGroupRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProjectGroups/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProjectGroupResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProjectGroupResponseModel> GetProjectGroupByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectGroups/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProjectGroupResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProjectGroupResponseModel>> GetProjectGroupByDataVersion(byte[] dataVersion)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectGroups/byDataVersion/{dataVersion}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProjectGroupResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProjectTriggerResponseModel>> ProjectTriggerCreateAsync(ApiProjectTriggerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProjectTriggers", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProjectTriggerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProjectTriggerResponseModel>> ProjectTriggerUpdateAsync(string id, ApiProjectTriggerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProjectTriggers/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProjectTriggerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProjectTriggerDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProjectTriggers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProjectTriggerResponseModel> ProjectTriggerGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectTriggers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProjectTriggerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProjectTriggerResponseModel>> ProjectTriggerAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectTriggers?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProjectTriggerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProjectTriggerResponseModel>> ProjectTriggerBulkInsertAsync(List<ApiProjectTriggerRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProjectTriggers/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProjectTriggerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProjectTriggerResponseModel> GetProjectTriggerByProjectIdName(string projectId, string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectTriggers/byProjectIdName/{projectId}/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProjectTriggerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProjectTriggerResponseModel>> GetProjectTriggerByProjectId(string projectId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectTriggers/byProjectId/{projectId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProjectTriggerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProxyResponseModel>> ProxyCreateAsync(ApiProxyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Proxies", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProxyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProxyResponseModel>> ProxyUpdateAsync(string id, ApiProxyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Proxies/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProxyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProxyDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Proxies/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProxyResponseModel> ProxyGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Proxies/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProxyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProxyResponseModel>> ProxyAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Proxies?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProxyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProxyResponseModel>> ProxyBulkInsertAsync(List<ApiProxyRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Proxies/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProxyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProxyResponseModel> GetProxyByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Proxies/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProxyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiReleaseResponseModel>> ReleaseCreateAsync(ApiReleaseRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Releases", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiReleaseResponseModel>> ReleaseUpdateAsync(string id, ApiReleaseRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Releases/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ReleaseDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Releases/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiReleaseResponseModel> ReleaseGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiReleaseResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiReleaseResponseModel>> ReleaseAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiReleaseResponseModel>> ReleaseBulkInsertAsync(List<ApiReleaseRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Releases/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiReleaseResponseModel> GetReleaseByVersionProjectId(string version, string projectId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases/byVersionProjectId/{version}/{projectId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiReleaseResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiReleaseResponseModel>> GetReleaseByIdAssembled(string id, DateTimeOffset assembled)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases/byIdAssembled/{id}/{assembled}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiReleaseResponseModel>> GetReleaseByProjectDeploymentProcessSnapshotId(string projectDeploymentProcessSnapshotId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases/byProjectDeploymentProcessSnapshotId/{projectDeploymentProcessSnapshotId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiReleaseResponseModel>> GetReleaseByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(string id, string version, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string channelId, DateTimeOffset assembled)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases/byIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled/{id}/{version}/{projectVariableSetSnapshotId}/{projectDeploymentProcessSnapshotId}/{jSON}/{projectId}/{channelId}/{assembled}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiReleaseResponseModel>> GetReleaseByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(string id, string channelId, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string version, DateTimeOffset assembled)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases/byIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled/{id}/{channelId}/{projectVariableSetSnapshotId}/{projectDeploymentProcessSnapshotId}/{jSON}/{projectId}/{version}/{assembled}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSchemaVersionsResponseModel>> SchemaVersionsCreateAsync(ApiSchemaVersionsRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SchemaVersions", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSchemaVersionsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSchemaVersionsResponseModel>> SchemaVersionsUpdateAsync(int id, ApiSchemaVersionsRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SchemaVersions/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSchemaVersionsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SchemaVersionsDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SchemaVersions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSchemaVersionsResponseModel> SchemaVersionsGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SchemaVersions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSchemaVersionsResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSchemaVersionsResponseModel>> SchemaVersionsAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SchemaVersions?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSchemaVersionsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSchemaVersionsResponseModel>> SchemaVersionsBulkInsertAsync(List<ApiSchemaVersionsRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SchemaVersions/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSchemaVersionsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiServerTaskResponseModel>> ServerTaskCreateAsync(ApiServerTaskRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ServerTasks", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiServerTaskResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiServerTaskResponseModel>> ServerTaskUpdateAsync(string id, ApiServerTaskRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ServerTasks/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiServerTaskResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ServerTaskDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ServerTasks/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiServerTaskResponseModel> ServerTaskGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ServerTasks/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiServerTaskResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiServerTaskResponseModel>> ServerTaskAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ServerTasks?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiServerTaskResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiServerTaskResponseModel>> ServerTaskBulkInsertAsync(List<ApiServerTaskRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ServerTasks/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiServerTaskResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiServerTaskResponseModel>> GetServerTaskByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(string description, DateTimeOffset queueTime, DateTimeOffset? startTime, DateTimeOffset? completedTime, string errorMessage, string concurrencyTag, bool hasPendingInterruptions, bool hasWarningsOrErrors, int durationSeconds, string jSON, string state, string name, string projectId, string environmentId, string tenantId, string serverNodeId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ServerTasks/byDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId/{description}/{queueTime}/{startTime}/{completedTime}/{errorMessage}/{concurrencyTag}/{hasPendingInterruptions}/{hasWarningsOrErrors}/{durationSeconds}/{jSON}/{state}/{name}/{projectId}/{environmentId}/{tenantId}/{serverNodeId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiServerTaskResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiServerTaskResponseModel>> GetServerTaskByStateConcurrencyTag(string state, string concurrencyTag)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ServerTasks/byStateConcurrencyTag/{state}/{concurrencyTag}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiServerTaskResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiServerTaskResponseModel>> GetServerTaskByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(string name, string description, DateTimeOffset? startTime, DateTimeOffset? completedTime, string errorMessage, bool hasWarningsOrErrors, string projectId, string environmentId, string tenantId, int durationSeconds, string jSON, DateTimeOffset queueTime, string state, string concurrencyTag, bool hasPendingInterruptions, string serverNodeId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ServerTasks/byNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId/{name}/{description}/{startTime}/{completedTime}/{errorMessage}/{hasWarningsOrErrors}/{projectId}/{environmentId}/{tenantId}/{durationSeconds}/{jSON}/{queueTime}/{state}/{concurrencyTag}/{hasPendingInterruptions}/{serverNodeId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiServerTaskResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSubscriptionResponseModel>> SubscriptionCreateAsync(ApiSubscriptionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Subscriptions", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSubscriptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSubscriptionResponseModel>> SubscriptionUpdateAsync(string id, ApiSubscriptionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Subscriptions/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSubscriptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SubscriptionDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Subscriptions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSubscriptionResponseModel> SubscriptionGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Subscriptions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSubscriptionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSubscriptionResponseModel>> SubscriptionAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Subscriptions?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSubscriptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSubscriptionResponseModel>> SubscriptionBulkInsertAsync(List<ApiSubscriptionRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Subscriptions/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSubscriptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSubscriptionResponseModel> GetSubscriptionByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Subscriptions/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSubscriptionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTagSetResponseModel>> TagSetCreateAsync(ApiTagSetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TagSets", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTagSetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTagSetResponseModel>> TagSetUpdateAsync(string id, ApiTagSetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TagSets/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTagSetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TagSetDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TagSets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTagSetResponseModel> TagSetGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TagSets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTagSetResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTagSetResponseModel>> TagSetAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TagSets?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTagSetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTagSetResponseModel>> TagSetBulkInsertAsync(List<ApiTagSetRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TagSets/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTagSetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTagSetResponseModel> GetTagSetByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TagSets/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTagSetResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTagSetResponseModel>> GetTagSetByDataVersion(byte[] dataVersion)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TagSets/byDataVersion/{dataVersion}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTagSetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTeamResponseModel>> TeamCreateAsync(ApiTeamRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTeamResponseModel>> TeamUpdateAsync(string id, ApiTeamRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Teams/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TeamDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Teams/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeamResponseModel> TeamGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeamResponseModel>> TeamAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeamResponseModel>> TeamBulkInsertAsync(List<ApiTeamRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeamResponseModel> GetTeamByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTenantResponseModel>> TenantCreateAsync(ApiTenantRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tenants", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTenantResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTenantResponseModel>> TenantUpdateAsync(string id, ApiTenantRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Tenants/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTenantResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TenantDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Tenants/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTenantResponseModel> TenantGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tenants/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTenantResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTenantResponseModel>> TenantAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tenants?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTenantResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTenantResponseModel>> TenantBulkInsertAsync(List<ApiTenantRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tenants/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTenantResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTenantResponseModel> GetTenantByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tenants/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTenantResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTenantResponseModel>> GetTenantByDataVersion(byte[] dataVersion)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tenants/byDataVersion/{dataVersion}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTenantResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTenantVariableResponseModel>> TenantVariableCreateAsync(ApiTenantVariableRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TenantVariables", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTenantVariableResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTenantVariableResponseModel>> TenantVariableUpdateAsync(string id, ApiTenantVariableRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TenantVariables/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTenantVariableResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TenantVariableDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TenantVariables/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTenantVariableResponseModel> TenantVariableGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TenantVariables/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTenantVariableResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTenantVariableResponseModel>> TenantVariableAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TenantVariables?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTenantVariableResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTenantVariableResponseModel>> TenantVariableBulkInsertAsync(List<ApiTenantVariableRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TenantVariables/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTenantVariableResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTenantVariableResponseModel> GetTenantVariableByTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TenantVariables/byTenantIdOwnerIdEnvironmentIdVariableTemplateId/{tenantId}/{ownerId}/{environmentId}/{variableTemplateId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTenantVariableResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTenantVariableResponseModel>> GetTenantVariableByTenantId(string tenantId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TenantVariables/byTenantId/{tenantId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTenantVariableResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiUserResponseModel>> UserCreateAsync(ApiUserRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Users", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiUserResponseModel>> UserUpdateAsync(string id, ApiUserRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Users/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> UserDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Users/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUserResponseModel> UserGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiUserResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserResponseModel>> UserAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserResponseModel>> UserBulkInsertAsync(List<ApiUserRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Users/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUserResponseModel> GetUserByUsername(string username)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/byUsername/{username}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiUserResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserResponseModel>> GetUserByDisplayName(string displayName)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/byDisplayName/{displayName}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserResponseModel>> GetUserByEmailAddress(string emailAddress)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/byEmailAddress/{emailAddress}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserResponseModel>> GetUserByExternalId(string externalId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/byExternalId/{externalId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiUserRoleResponseModel>> UserRoleCreateAsync(ApiUserRoleRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UserRoles", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiUserRoleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiUserRoleResponseModel>> UserRoleUpdateAsync(string id, ApiUserRoleRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/UserRoles/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiUserRoleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> UserRoleDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/UserRoles/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUserRoleResponseModel> UserRoleGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UserRoles/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiUserRoleResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserRoleResponseModel>> UserRoleAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UserRoles?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserRoleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserRoleResponseModel>> UserRoleBulkInsertAsync(List<ApiUserRoleRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UserRoles/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserRoleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUserRoleResponseModel> GetUserRoleByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UserRoles/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiUserRoleResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiVariableSetResponseModel>> VariableSetCreateAsync(ApiVariableSetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VariableSets", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiVariableSetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiVariableSetResponseModel>> VariableSetUpdateAsync(string id, ApiVariableSetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/VariableSets/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiVariableSetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> VariableSetDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/VariableSets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVariableSetResponseModel> VariableSetGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VariableSets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVariableSetResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVariableSetResponseModel>> VariableSetAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VariableSets?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVariableSetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVariableSetResponseModel>> VariableSetBulkInsertAsync(List<ApiVariableSetRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VariableSets/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVariableSetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiWorkerResponseModel>> WorkerCreateAsync(ApiWorkerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Workers", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiWorkerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiWorkerResponseModel>> WorkerUpdateAsync(string id, ApiWorkerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Workers/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiWorkerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> WorkerDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Workers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiWorkerResponseModel> WorkerGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Workers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiWorkerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkerResponseModel>> WorkerAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Workers?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkerResponseModel>> WorkerBulkInsertAsync(List<ApiWorkerRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Workers/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiWorkerResponseModel> GetWorkerByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Workers/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiWorkerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkerResponseModel>> GetWorkerByMachinePolicyId(string machinePolicyId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Workers/byMachinePolicyId/{machinePolicyId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiWorkerPoolResponseModel>> WorkerPoolCreateAsync(ApiWorkerPoolRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkerPools", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiWorkerPoolResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiWorkerPoolResponseModel>> WorkerPoolUpdateAsync(string id, ApiWorkerPoolRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/WorkerPools/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiWorkerPoolResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> WorkerPoolDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/WorkerPools/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiWorkerPoolResponseModel> WorkerPoolGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkerPools/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiWorkerPoolResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkerPoolResponseModel>> WorkerPoolAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkerPools?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkerPoolResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkerPoolResponseModel>> WorkerPoolBulkInsertAsync(List<ApiWorkerPoolRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkerPools/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkerPoolResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiWorkerPoolResponseModel> GetWorkerPoolByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkerPools/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiWorkerPoolResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiWorkerTaskLeaseResponseModel>> WorkerTaskLeaseCreateAsync(ApiWorkerTaskLeaseRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkerTaskLeases", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiWorkerTaskLeaseResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiWorkerTaskLeaseResponseModel>> WorkerTaskLeaseUpdateAsync(string id, ApiWorkerTaskLeaseRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/WorkerTaskLeases/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiWorkerTaskLeaseResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> WorkerTaskLeaseDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/WorkerTaskLeases/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiWorkerTaskLeaseResponseModel> WorkerTaskLeaseGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkerTaskLeases/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiWorkerTaskLeaseResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkerTaskLeaseResponseModel>> WorkerTaskLeaseAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkerTaskLeases?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkerTaskLeaseResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkerTaskLeaseResponseModel>> WorkerTaskLeaseBulkInsertAsync(List<ApiWorkerTaskLeaseRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkerTaskLeases/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkerTaskLeaseResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>0ac89e43af720b0b9edcb8c4da0cf67d</Hash>
</Codenesium>*/