using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Client
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

		public virtual async Task<ApiAirlineResponseModel> AirlineCreateAsync(ApiAirlineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Airlines", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAirlineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAirlineResponseModel> AirlineUpdateAsync(int id, ApiAirlineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Airlines/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAirlineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task AirlineDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Airlines/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiAirlineResponseModel> AirlineGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Airlines/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAirlineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAirlineResponseModel>> AirlineAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Airlines?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiAirlineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAirlineResponseModel>> AirlineBulkInsertAsync(List<ApiAirlineRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Airlines/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiAirlineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAirTransportResponseModel> AirTransportCreateAsync(ApiAirTransportRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AirTransports", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAirTransportResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAirTransportResponseModel> AirTransportUpdateAsync(int id, ApiAirTransportRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/AirTransports/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAirTransportResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task AirTransportDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/AirTransports/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiAirTransportResponseModel> AirTransportGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AirTransports/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAirTransportResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAirTransportResponseModel>> AirTransportAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AirTransports?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiAirTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAirTransportResponseModel>> AirTransportBulkInsertAsync(List<ApiAirTransportRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AirTransports/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiAirTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBreedResponseModel> BreedCreateAsync(ApiBreedRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Breeds", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBreedResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBreedResponseModel> BreedUpdateAsync(int id, ApiBreedRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Breeds/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBreedResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task BreedDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Breeds/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiBreedResponseModel> BreedGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Breeds/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBreedResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBreedResponseModel>> BreedAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Breeds?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBreedResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBreedResponseModel>> BreedBulkInsertAsync(List<ApiBreedRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Breeds/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBreedResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiClientResponseModel> ClientCreateAsync(ApiClientRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clients", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiClientResponseModel> ClientUpdateAsync(int id, ApiClientRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Clients/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ClientDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Clients/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiClientResponseModel> ClientGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clients/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClientResponseModel>> ClientAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clients?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClientResponseModel>> ClientBulkInsertAsync(List<ApiClientRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clients/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiClientCommunicationResponseModel> ClientCommunicationCreateAsync(ApiClientCommunicationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ClientCommunications", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiClientCommunicationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiClientCommunicationResponseModel> ClientCommunicationUpdateAsync(int id, ApiClientCommunicationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ClientCommunications/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiClientCommunicationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ClientCommunicationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ClientCommunications/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiClientCommunicationResponseModel> ClientCommunicationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ClientCommunications/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiClientCommunicationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClientCommunicationResponseModel>> ClientCommunicationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ClientCommunications?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiClientCommunicationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClientCommunicationResponseModel>> ClientCommunicationBulkInsertAsync(List<ApiClientCommunicationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ClientCommunications/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiClientCommunicationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryResponseModel> CountryCreateAsync(ApiCountryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Countries", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCountryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryResponseModel> CountryUpdateAsync(int id, ApiCountryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Countries/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCountryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CountryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Countries/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiCountryResponseModel> CountryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Countries/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCountryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryResponseModel>> CountryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Countries?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCountryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryResponseModel>> CountryBulkInsertAsync(List<ApiCountryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Countries/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCountryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryRequirementResponseModel> CountryRequirementCreateAsync(ApiCountryRequirementRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRequirements", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCountryRequirementResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryRequirementResponseModel> CountryRequirementUpdateAsync(int id, ApiCountryRequirementRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CountryRequirements/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCountryRequirementResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CountryRequirementDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CountryRequirements/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiCountryRequirementResponseModel> CountryRequirementGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRequirements/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCountryRequirementResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryRequirementResponseModel>> CountryRequirementAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRequirements?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCountryRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryRequirementResponseModel>> CountryRequirementBulkInsertAsync(List<ApiCountryRequirementRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRequirements/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCountryRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDestinationResponseModel> DestinationCreateAsync(ApiDestinationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Destinations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDestinationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDestinationResponseModel> DestinationUpdateAsync(int id, ApiDestinationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Destinations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDestinationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task DestinationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Destinations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiDestinationResponseModel> DestinationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Destinations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDestinationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDestinationResponseModel>> DestinationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Destinations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDestinationResponseModel>> DestinationBulkInsertAsync(List<ApiDestinationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Destinations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeeResponseModel> EmployeeCreateAsync(ApiEmployeeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeeResponseModel> EmployeeUpdateAsync(int id, ApiEmployeeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Employees/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmployeeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Employees/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiEmployeeResponseModel> EmployeeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> EmployeeAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> EmployeeBulkInsertAsync(List<ApiEmployeeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiHandlerResponseModel> HandlerCreateAsync(ApiHandlerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Handlers", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiHandlerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiHandlerResponseModel> HandlerUpdateAsync(int id, ApiHandlerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Handlers/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiHandlerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task HandlerDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Handlers/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiHandlerResponseModel> HandlerGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Handlers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiHandlerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiHandlerResponseModel>> HandlerAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Handlers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiHandlerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiHandlerResponseModel>> HandlerBulkInsertAsync(List<ApiHandlerRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Handlers/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiHandlerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiHandlerPipelineStepResponseModel> HandlerPipelineStepCreateAsync(ApiHandlerPipelineStepRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/HandlerPipelineSteps", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiHandlerPipelineStepResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiHandlerPipelineStepResponseModel> HandlerPipelineStepUpdateAsync(int id, ApiHandlerPipelineStepRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/HandlerPipelineSteps/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiHandlerPipelineStepResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task HandlerPipelineStepDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/HandlerPipelineSteps/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiHandlerPipelineStepResponseModel> HandlerPipelineStepGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/HandlerPipelineSteps/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiHandlerPipelineStepResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineStepAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/HandlerPipelineSteps?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiHandlerPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineStepBulkInsertAsync(List<ApiHandlerPipelineStepRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/HandlerPipelineSteps/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiHandlerPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiOtherTransportResponseModel> OtherTransportCreateAsync(ApiOtherTransportRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/OtherTransports", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiOtherTransportResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiOtherTransportResponseModel> OtherTransportUpdateAsync(int id, ApiOtherTransportRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/OtherTransports/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiOtherTransportResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task OtherTransportDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/OtherTransports/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiOtherTransportResponseModel> OtherTransportGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/OtherTransports/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiOtherTransportResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiOtherTransportResponseModel>> OtherTransportAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/OtherTransports?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiOtherTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiOtherTransportResponseModel>> OtherTransportBulkInsertAsync(List<ApiOtherTransportRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/OtherTransports/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiOtherTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPetResponseModel> PetCreateAsync(ApiPetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pets", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPetResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPetResponseModel> PetUpdateAsync(int id, ApiPetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Pets/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPetResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PetDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Pets/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPetResponseModel> PetGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pets/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPetResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPetResponseModel>> PetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pets?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPetResponseModel>> PetBulkInsertAsync(List<ApiPetRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pets/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineResponseModel> PipelineCreateAsync(ApiPipelineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pipelines", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineResponseModel> PipelineUpdateAsync(int id, ApiPipelineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Pipelines/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Pipelines/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPipelineResponseModel> PipelineGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pipelines/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineResponseModel>> PipelineAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pipelines?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineResponseModel>> PipelineBulkInsertAsync(List<ApiPipelineRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pipelines/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStatusResponseModel> PipelineStatusCreateAsync(ApiPipelineStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStatusResponseModel> PipelineStatusUpdateAsync(int id, ApiPipelineStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPipelineStatusResponseModel> PipelineStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStatusResponseModel>> PipelineStatusAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStatusResponseModel>> PipelineStatusBulkInsertAsync(List<ApiPipelineStatusRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStatus/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepResponseModel> PipelineStepCreateAsync(ApiPipelineStepRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineSteps", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepResponseModel> PipelineStepUpdateAsync(int id, ApiPipelineStepRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineSteps/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineStepDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineSteps/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPipelineStepResponseModel> PipelineStepGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineSteps/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepResponseModel>> PipelineStepAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineSteps?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepResponseModel>> PipelineStepBulkInsertAsync(List<ApiPipelineStepRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineSteps/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepDestinationResponseModel> PipelineStepDestinationCreateAsync(ApiPipelineStepDestinationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepDestinations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepDestinationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepDestinationResponseModel> PipelineStepDestinationUpdateAsync(int id, ApiPipelineStepDestinationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStepDestinations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepDestinationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineStepDestinationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStepDestinations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPipelineStepDestinationResponseModel> PipelineStepDestinationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepDestinations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepDestinationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepDestinations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineStepDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinationBulkInsertAsync(List<ApiPipelineStepDestinationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepDestinations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineStepDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepNoteResponseModel> PipelineStepNoteCreateAsync(ApiPipelineStepNoteRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepNotes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepNoteResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepNoteResponseModel> PipelineStepNoteUpdateAsync(int id, ApiPipelineStepNoteRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStepNotes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepNoteResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineStepNoteDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStepNotes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPipelineStepNoteResponseModel> PipelineStepNoteGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepNotes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepNoteResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNoteAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepNotes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineStepNoteResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNoteBulkInsertAsync(List<ApiPipelineStepNoteRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepNotes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineStepNoteResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepStatusResponseModel> PipelineStepStatusCreateAsync(ApiPipelineStepStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepStatusResponseModel> PipelineStepStatusUpdateAsync(int id, ApiPipelineStepStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStepStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineStepStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStepStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPipelineStepStatusResponseModel> PipelineStepStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepStatusResponseModel>> PipelineStepStatusAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineStepStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepStatusResponseModel>> PipelineStepStatusBulkInsertAsync(List<ApiPipelineStepStatusRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepStatus/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineStepStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepStepRequirementResponseModel> PipelineStepStepRequirementCreateAsync(ApiPipelineStepStepRequirementRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepStepRequirements", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepStepRequirementResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepStepRequirementResponseModel> PipelineStepStepRequirementUpdateAsync(int id, ApiPipelineStepStepRequirementRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStepStepRequirements/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepStepRequirementResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineStepStepRequirementDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStepStepRequirements/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPipelineStepStepRequirementResponseModel> PipelineStepStepRequirementGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepStepRequirements/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPipelineStepStepRequirementResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirementAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepStepRequirements?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineStepStepRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirementBulkInsertAsync(List<ApiPipelineStepStepRequirementRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepStepRequirements/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPipelineStepStepRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSaleResponseModel> SaleCreateAsync(ApiSaleRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Sales", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSaleResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSaleResponseModel> SaleUpdateAsync(int id, ApiSaleRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Sales/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSaleResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SaleDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Sales/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiSaleResponseModel> SaleGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSaleResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSaleResponseModel>> SaleAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSaleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSaleResponseModel>> SaleBulkInsertAsync(List<ApiSaleRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Sales/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSaleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpeciesResponseModel> SpeciesCreateAsync(ApiSpeciesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Species", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSpeciesResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpeciesResponseModel> SpeciesUpdateAsync(int id, ApiSpeciesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Species/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSpeciesResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpeciesDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Species/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiSpeciesResponseModel> SpeciesGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Species/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSpeciesResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpeciesResponseModel>> SpeciesAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Species?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSpeciesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpeciesResponseModel>> SpeciesBulkInsertAsync(List<ApiSpeciesRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Species/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSpeciesResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>2c7fcd1fb26e6570c882ebc5c954fb61</Hash>
</Codenesium>*/