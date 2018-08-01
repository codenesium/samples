using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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

		public virtual async Task<CreateResponse<ApiAirlineResponseModel>> AirlineCreateAsync(ApiAirlineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Airlines", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiAirlineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiAirlineResponseModel>> AirlineUpdateAsync(int id, ApiAirlineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Airlines/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiAirlineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> AirlineDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Airlines/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAirlineResponseModel> AirlineGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Airlines/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiAirlineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAirlineResponseModel>> AirlineAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Airlines?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAirlineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAirlineResponseModel>> AirlineBulkInsertAsync(List<ApiAirlineRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Airlines/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAirlineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiAirTransportResponseModel>> AirTransportCreateAsync(ApiAirTransportRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AirTransports", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiAirTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiAirTransportResponseModel>> AirTransportUpdateAsync(int id, ApiAirTransportRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/AirTransports/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiAirTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> AirTransportDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/AirTransports/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAirTransportResponseModel> AirTransportGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AirTransports/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiAirTransportResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAirTransportResponseModel>> AirTransportAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AirTransports?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAirTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAirTransportResponseModel>> AirTransportBulkInsertAsync(List<ApiAirTransportRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AirTransports/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAirTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiBreedResponseModel>> BreedCreateAsync(ApiBreedRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Breeds", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiBreedResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiBreedResponseModel>> BreedUpdateAsync(int id, ApiBreedRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Breeds/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiBreedResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> BreedDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Breeds/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBreedResponseModel> BreedGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Breeds/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiBreedResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBreedResponseModel>> BreedAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Breeds?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBreedResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBreedResponseModel>> BreedBulkInsertAsync(List<ApiBreedRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Breeds/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBreedResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPetResponseModel>> Pets(int breedId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Breeds/Pets/{breedId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiClientResponseModel>> ClientCreateAsync(ApiClientRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clients", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiClientResponseModel>> ClientUpdateAsync(int id, ApiClientRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Clients/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ClientDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Clients/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiClientResponseModel> ClientGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clients/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClientResponseModel>> ClientAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clients?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClientResponseModel>> ClientBulkInsertAsync(List<ApiClientRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clients/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClientCommunicationResponseModel>> ClientCommunications(int clientId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clients/ClientCommunications/{clientId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiClientCommunicationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSaleResponseModel>> Sales(int clientId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clients/Sales/{clientId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSaleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiClientCommunicationResponseModel>> ClientCommunicationCreateAsync(ApiClientCommunicationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ClientCommunications", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiClientCommunicationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiClientCommunicationResponseModel>> ClientCommunicationUpdateAsync(int id, ApiClientCommunicationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ClientCommunications/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiClientCommunicationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ClientCommunicationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ClientCommunications/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiClientCommunicationResponseModel> ClientCommunicationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ClientCommunications/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiClientCommunicationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClientCommunicationResponseModel>> ClientCommunicationAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ClientCommunications?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiClientCommunicationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClientCommunicationResponseModel>> ClientCommunicationBulkInsertAsync(List<ApiClientCommunicationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ClientCommunications/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiClientCommunicationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCountryResponseModel>> CountryCreateAsync(ApiCountryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Countries", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCountryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCountryResponseModel>> CountryUpdateAsync(int id, ApiCountryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Countries/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCountryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CountryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Countries/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryResponseModel> CountryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Countries/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCountryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryResponseModel>> CountryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Countries?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCountryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryResponseModel>> CountryBulkInsertAsync(List<ApiCountryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Countries/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCountryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryRequirementResponseModel>> CountryRequirements(int countryId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Countries/CountryRequirements/{countryId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCountryRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDestinationResponseModel>> Destinations(int countryId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Countries/Destinations/{countryId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCountryRequirementResponseModel>> CountryRequirementCreateAsync(ApiCountryRequirementRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRequirements", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCountryRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCountryRequirementResponseModel>> CountryRequirementUpdateAsync(int id, ApiCountryRequirementRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CountryRequirements/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCountryRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CountryRequirementDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CountryRequirements/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryRequirementResponseModel> CountryRequirementGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRequirements/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCountryRequirementResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryRequirementResponseModel>> CountryRequirementAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRequirements?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCountryRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryRequirementResponseModel>> CountryRequirementBulkInsertAsync(List<ApiCountryRequirementRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRequirements/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCountryRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDestinationResponseModel>> DestinationCreateAsync(ApiDestinationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Destinations", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDestinationResponseModel>> DestinationUpdateAsync(int id, ApiDestinationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Destinations/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DestinationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Destinations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDestinationResponseModel> DestinationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Destinations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDestinationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDestinationResponseModel>> DestinationAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Destinations?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDestinationResponseModel>> DestinationBulkInsertAsync(List<ApiDestinationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Destinations/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinations(int destinationId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Destinations/PipelineStepDestinations/{destinationId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiEmployeeResponseModel>> EmployeeCreateAsync(ApiEmployeeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiEmployeeResponseModel>> EmployeeUpdateAsync(int id, ApiEmployeeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Employees/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> EmployeeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Employees/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeeResponseModel> EmployeeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> EmployeeAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> EmployeeBulkInsertAsync(List<ApiEmployeeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepResponseModel>> PipelineSteps(int shipperId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/PipelineSteps/{shipperId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNotes(int employeeId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/PipelineStepNotes/{employeeId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepNoteResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiHandlerResponseModel>> HandlerCreateAsync(ApiHandlerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Handlers", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiHandlerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiHandlerResponseModel>> HandlerUpdateAsync(int id, ApiHandlerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Handlers/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiHandlerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> HandlerDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Handlers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiHandlerResponseModel> HandlerGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Handlers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiHandlerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiHandlerResponseModel>> HandlerAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Handlers?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiHandlerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiHandlerResponseModel>> HandlerBulkInsertAsync(List<ApiHandlerRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Handlers/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiHandlerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAirTransportResponseModel>> AirTransports(int handlerId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Handlers/AirTransports/{handlerId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAirTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineSteps(int handlerId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Handlers/HandlerPipelineSteps/{handlerId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiHandlerPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiOtherTransportResponseModel>> OtherTransports(int handlerId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Handlers/OtherTransports/{handlerId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiOtherTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiHandlerPipelineStepResponseModel>> HandlerPipelineStepCreateAsync(ApiHandlerPipelineStepRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/HandlerPipelineSteps", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiHandlerPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiHandlerPipelineStepResponseModel>> HandlerPipelineStepUpdateAsync(int id, ApiHandlerPipelineStepRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/HandlerPipelineSteps/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiHandlerPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> HandlerPipelineStepDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/HandlerPipelineSteps/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiHandlerPipelineStepResponseModel> HandlerPipelineStepGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/HandlerPipelineSteps/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiHandlerPipelineStepResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineStepAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/HandlerPipelineSteps?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiHandlerPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineStepBulkInsertAsync(List<ApiHandlerPipelineStepRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/HandlerPipelineSteps/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiHandlerPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiOtherTransportResponseModel>> OtherTransportCreateAsync(ApiOtherTransportRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/OtherTransports", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiOtherTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiOtherTransportResponseModel>> OtherTransportUpdateAsync(int id, ApiOtherTransportRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/OtherTransports/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiOtherTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> OtherTransportDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/OtherTransports/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiOtherTransportResponseModel> OtherTransportGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/OtherTransports/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiOtherTransportResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiOtherTransportResponseModel>> OtherTransportAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/OtherTransports?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiOtherTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiOtherTransportResponseModel>> OtherTransportBulkInsertAsync(List<ApiOtherTransportRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/OtherTransports/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiOtherTransportResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPetResponseModel>> PetCreateAsync(ApiPetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pets", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPetResponseModel>> PetUpdateAsync(int id, ApiPetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Pets/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PetDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Pets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPetResponseModel> PetGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPetResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPetResponseModel>> PetAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pets?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPetResponseModel>> PetBulkInsertAsync(List<ApiPetRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pets/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPipelineResponseModel>> PipelineCreateAsync(ApiPipelineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pipelines", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPipelineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPipelineResponseModel>> PipelineUpdateAsync(int id, ApiPipelineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Pipelines/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPipelineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PipelineDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Pipelines/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineResponseModel> PipelineGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pipelines/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPipelineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineResponseModel>> PipelineAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pipelines?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineResponseModel>> PipelineBulkInsertAsync(List<ApiPipelineRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pipelines/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPipelineStatusResponseModel>> PipelineStatusCreateAsync(ApiPipelineStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStatus", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPipelineStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPipelineStatusResponseModel>> PipelineStatusUpdateAsync(int id, ApiPipelineStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStatus/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPipelineStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PipelineStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStatusResponseModel> PipelineStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPipelineStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStatusResponseModel>> PipelineStatusAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStatus?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStatusResponseModel>> PipelineStatusBulkInsertAsync(List<ApiPipelineStatusRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStatus/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineResponseModel>> Pipelines(int pipelineStatusId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStatus/Pipelines/{pipelineStatusId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPipelineStepResponseModel>> PipelineStepCreateAsync(ApiPipelineStepRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineSteps", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepResponseModel>> PipelineStepUpdateAsync(int id, ApiPipelineStepRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineSteps/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PipelineStepDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineSteps/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepResponseModel> PipelineStepGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineSteps/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPipelineStepResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepResponseModel>> PipelineStepAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineSteps?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepResponseModel>> PipelineStepBulkInsertAsync(List<ApiPipelineStepRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineSteps/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirements(int pipelineStepId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineSteps/PipelineStepStepRequirements/{pipelineStepId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepStepRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinationCreateAsync(ApiPipelineStepDestinationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepDestinations", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPipelineStepDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinationUpdateAsync(int id, ApiPipelineStepDestinationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStepDestinations/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPipelineStepDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PipelineStepDestinationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStepDestinations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepDestinationResponseModel> PipelineStepDestinationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepDestinations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPipelineStepDestinationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinationAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepDestinations?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinationBulkInsertAsync(List<ApiPipelineStepDestinationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepDestinations/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepDestinationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPipelineStepNoteResponseModel>> PipelineStepNoteCreateAsync(ApiPipelineStepNoteRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepNotes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPipelineStepNoteResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepNoteResponseModel>> PipelineStepNoteUpdateAsync(int id, ApiPipelineStepNoteRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStepNotes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPipelineStepNoteResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PipelineStepNoteDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStepNotes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepNoteResponseModel> PipelineStepNoteGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepNotes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPipelineStepNoteResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNoteAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepNotes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepNoteResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNoteBulkInsertAsync(List<ApiPipelineStepNoteRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepNotes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepNoteResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPipelineStepStatusResponseModel>> PipelineStepStatusCreateAsync(ApiPipelineStepStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepStatus", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPipelineStepStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepStatusResponseModel>> PipelineStepStatusUpdateAsync(int id, ApiPipelineStepStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStepStatus/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPipelineStepStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PipelineStepStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStepStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepStatusResponseModel> PipelineStepStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPipelineStepStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepStatusResponseModel>> PipelineStepStatusAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepStatus?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepStatusResponseModel>> PipelineStepStatusBulkInsertAsync(List<ApiPipelineStepStatusRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepStatus/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirementCreateAsync(ApiPipelineStepStepRequirementRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepStepRequirements", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPipelineStepStepRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirementUpdateAsync(int id, ApiPipelineStepStepRequirementRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStepStepRequirements/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPipelineStepStepRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PipelineStepStepRequirementDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStepStepRequirements/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPipelineStepStepRequirementResponseModel> PipelineStepStepRequirementGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepStepRequirements/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPipelineStepStepRequirementResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirementAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepStepRequirements?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepStepRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirementBulkInsertAsync(List<ApiPipelineStepStepRequirementRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepStepRequirements/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPipelineStepStepRequirementResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSaleResponseModel>> SaleCreateAsync(ApiSaleRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Sales", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSaleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSaleResponseModel>> SaleUpdateAsync(int id, ApiSaleRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Sales/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSaleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SaleDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Sales/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSaleResponseModel> SaleGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSaleResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSaleResponseModel>> SaleAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSaleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSaleResponseModel>> SaleBulkInsertAsync(List<ApiSaleRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Sales/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSaleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSpeciesResponseModel>> SpeciesCreateAsync(ApiSpeciesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Species", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSpeciesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSpeciesResponseModel>> SpeciesUpdateAsync(int id, ApiSpeciesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Species/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSpeciesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SpeciesDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Species/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpeciesResponseModel> SpeciesGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Species/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSpeciesResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpeciesResponseModel>> SpeciesAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Species?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpeciesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpeciesResponseModel>> SpeciesBulkInsertAsync(List<ApiSpeciesRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Species/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpeciesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBreedResponseModel>> Breeds(int speciesId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Species/Breeds/{speciesId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBreedResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>e37d0486250bce39aec16cca68c9df18</Hash>
</Codenesium>*/