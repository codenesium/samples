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

		public virtual async Task<POCOAirline> AirlineCreateAsync(ApiAirlineModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Airlines", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAirline>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAirline> AirlineUpdateAsync(int id, ApiAirlineModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Airlines/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAirline>(httpResponse.Content.ContentToString());
		}

		public virtual async Task AirlineDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Airlines/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOAirline> AirlineGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Airlines/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAirline>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAirline>> AirlineAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Airlines?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAirline>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAirline>> AirlineBulkInsertAsync(List<ApiAirlineModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Airlines/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAirline>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAirTransport> AirTransportCreateAsync(ApiAirTransportModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AirTransports", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAirTransport>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAirTransport> AirTransportUpdateAsync(int id, ApiAirTransportModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/AirTransports/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAirTransport>(httpResponse.Content.ContentToString());
		}

		public virtual async Task AirTransportDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/AirTransports/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOAirTransport> AirTransportGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AirTransports/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAirTransport>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAirTransport>> AirTransportAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AirTransports?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAirTransport>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAirTransport>> AirTransportBulkInsertAsync(List<ApiAirTransportModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AirTransports/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAirTransport>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBreed> BreedCreateAsync(ApiBreedModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Breeds", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBreed>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBreed> BreedUpdateAsync(int id, ApiBreedModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Breeds/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBreed>(httpResponse.Content.ContentToString());
		}

		public virtual async Task BreedDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Breeds/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOBreed> BreedGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Breeds/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBreed>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBreed>> BreedAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Breeds?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBreed>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBreed>> BreedBulkInsertAsync(List<ApiBreedModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Breeds/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBreed>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOClient> ClientCreateAsync(ApiClientModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clients", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOClient>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOClient> ClientUpdateAsync(int id, ApiClientModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Clients/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOClient>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ClientDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Clients/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOClient> ClientGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clients/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOClient>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOClient>> ClientAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clients?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOClient>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOClient>> ClientBulkInsertAsync(List<ApiClientModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clients/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOClient>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOClientCommunication> ClientCommunicationCreateAsync(ApiClientCommunicationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ClientCommunications", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOClientCommunication>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOClientCommunication> ClientCommunicationUpdateAsync(int id, ApiClientCommunicationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ClientCommunications/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOClientCommunication>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ClientCommunicationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ClientCommunications/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOClientCommunication> ClientCommunicationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ClientCommunications/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOClientCommunication>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOClientCommunication>> ClientCommunicationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ClientCommunications?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOClientCommunication>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOClientCommunication>> ClientCommunicationBulkInsertAsync(List<ApiClientCommunicationModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ClientCommunications/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOClientCommunication>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountry> CountryCreateAsync(ApiCountryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Countries", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountry>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountry> CountryUpdateAsync(int id, ApiCountryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Countries/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountry>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CountryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Countries/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOCountry> CountryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Countries/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountry>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCountry>> CountryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Countries?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCountry>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCountry>> CountryBulkInsertAsync(List<ApiCountryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Countries/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCountry>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountryRequirement> CountryRequirementCreateAsync(ApiCountryRequirementModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRequirements", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRequirement>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountryRequirement> CountryRequirementUpdateAsync(int id, ApiCountryRequirementModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CountryRequirements/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRequirement>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CountryRequirementDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CountryRequirements/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOCountryRequirement> CountryRequirementGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRequirements/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRequirement>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCountryRequirement>> CountryRequirementAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRequirements?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCountryRequirement>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCountryRequirement>> CountryRequirementBulkInsertAsync(List<ApiCountryRequirementModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRequirements/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCountryRequirement>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODestination> DestinationCreateAsync(ApiDestinationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Destinations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODestination>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODestination> DestinationUpdateAsync(int id, ApiDestinationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Destinations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODestination>(httpResponse.Content.ContentToString());
		}

		public virtual async Task DestinationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Destinations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCODestination> DestinationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Destinations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODestination>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCODestination>> DestinationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Destinations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODestination>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCODestination>> DestinationBulkInsertAsync(List<ApiDestinationModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Destinations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODestination>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployee> EmployeeCreateAsync(ApiEmployeeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployee>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployee> EmployeeUpdateAsync(int id, ApiEmployeeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Employees/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployee>(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmployeeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Employees/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOEmployee> EmployeeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployee>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployee>> EmployeeAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployee>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployee>> EmployeeBulkInsertAsync(List<ApiEmployeeModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployee>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOHandler> HandlerCreateAsync(ApiHandlerModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Handlers", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOHandler>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOHandler> HandlerUpdateAsync(int id, ApiHandlerModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Handlers/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOHandler>(httpResponse.Content.ContentToString());
		}

		public virtual async Task HandlerDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Handlers/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOHandler> HandlerGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Handlers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOHandler>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOHandler>> HandlerAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Handlers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOHandler>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOHandler>> HandlerBulkInsertAsync(List<ApiHandlerModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Handlers/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOHandler>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOHandlerPipelineStep> HandlerPipelineStepCreateAsync(ApiHandlerPipelineStepModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/HandlerPipelineSteps", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOHandlerPipelineStep>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOHandlerPipelineStep> HandlerPipelineStepUpdateAsync(int id, ApiHandlerPipelineStepModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/HandlerPipelineSteps/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOHandlerPipelineStep>(httpResponse.Content.ContentToString());
		}

		public virtual async Task HandlerPipelineStepDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/HandlerPipelineSteps/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOHandlerPipelineStep> HandlerPipelineStepGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/HandlerPipelineSteps/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOHandlerPipelineStep>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOHandlerPipelineStep>> HandlerPipelineStepAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/HandlerPipelineSteps?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOHandlerPipelineStep>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOHandlerPipelineStep>> HandlerPipelineStepBulkInsertAsync(List<ApiHandlerPipelineStepModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/HandlerPipelineSteps/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOHandlerPipelineStep>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOOtherTransport> OtherTransportCreateAsync(ApiOtherTransportModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/OtherTransports", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOOtherTransport>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOOtherTransport> OtherTransportUpdateAsync(int id, ApiOtherTransportModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/OtherTransports/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOOtherTransport>(httpResponse.Content.ContentToString());
		}

		public virtual async Task OtherTransportDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/OtherTransports/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOOtherTransport> OtherTransportGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/OtherTransports/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOOtherTransport>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOOtherTransport>> OtherTransportAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/OtherTransports?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOOtherTransport>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOOtherTransport>> OtherTransportBulkInsertAsync(List<ApiOtherTransportModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/OtherTransports/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOOtherTransport>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPet> PetCreateAsync(ApiPetModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pets", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPet>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPet> PetUpdateAsync(int id, ApiPetModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Pets/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPet>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PetDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Pets/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPet> PetGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pets/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPet>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPet>> PetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pets?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPet>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPet>> PetBulkInsertAsync(List<ApiPetModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pets/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPet>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipeline> PipelineCreateAsync(ApiPipelineModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pipelines", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipeline>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipeline> PipelineUpdateAsync(int id, ApiPipelineModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Pipelines/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipeline>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Pipelines/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPipeline> PipelineGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pipelines/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipeline>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipeline>> PipelineAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pipelines?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipeline>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipeline>> PipelineBulkInsertAsync(List<ApiPipelineModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pipelines/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipeline>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipelineStatus> PipelineStatusCreateAsync(ApiPipelineStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipelineStatus> PipelineStatusUpdateAsync(int id, ApiPipelineStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPipelineStatus> PipelineStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipelineStatus>> PipelineStatusAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipelineStatus>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipelineStatus>> PipelineStatusBulkInsertAsync(List<ApiPipelineStatusModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStatus/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipelineStatus>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipelineStep> PipelineStepCreateAsync(ApiPipelineStepModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineSteps", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStep>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipelineStep> PipelineStepUpdateAsync(int id, ApiPipelineStepModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineSteps/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStep>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineStepDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineSteps/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPipelineStep> PipelineStepGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineSteps/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStep>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipelineStep>> PipelineStepAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineSteps?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipelineStep>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipelineStep>> PipelineStepBulkInsertAsync(List<ApiPipelineStepModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineSteps/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipelineStep>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipelineStepDestination> PipelineStepDestinationCreateAsync(ApiPipelineStepDestinationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepDestinations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStepDestination>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipelineStepDestination> PipelineStepDestinationUpdateAsync(int id, ApiPipelineStepDestinationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStepDestinations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStepDestination>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineStepDestinationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStepDestinations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPipelineStepDestination> PipelineStepDestinationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepDestinations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStepDestination>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipelineStepDestination>> PipelineStepDestinationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepDestinations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipelineStepDestination>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipelineStepDestination>> PipelineStepDestinationBulkInsertAsync(List<ApiPipelineStepDestinationModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepDestinations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipelineStepDestination>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipelineStepNote> PipelineStepNoteCreateAsync(ApiPipelineStepNoteModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepNotes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStepNote>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipelineStepNote> PipelineStepNoteUpdateAsync(int id, ApiPipelineStepNoteModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStepNotes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStepNote>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineStepNoteDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStepNotes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPipelineStepNote> PipelineStepNoteGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepNotes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStepNote>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipelineStepNote>> PipelineStepNoteAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepNotes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipelineStepNote>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipelineStepNote>> PipelineStepNoteBulkInsertAsync(List<ApiPipelineStepNoteModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepNotes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipelineStepNote>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipelineStepStatus> PipelineStepStatusCreateAsync(ApiPipelineStepStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStepStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipelineStepStatus> PipelineStepStatusUpdateAsync(int id, ApiPipelineStepStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStepStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStepStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineStepStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStepStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPipelineStepStatus> PipelineStepStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStepStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipelineStepStatus>> PipelineStepStatusAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipelineStepStatus>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipelineStepStatus>> PipelineStepStatusBulkInsertAsync(List<ApiPipelineStepStatusModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepStatus/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipelineStepStatus>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipelineStepStepRequirement> PipelineStepStepRequirementCreateAsync(ApiPipelineStepStepRequirementModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepStepRequirements", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStepStepRequirement>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPipelineStepStepRequirement> PipelineStepStepRequirementUpdateAsync(int id, ApiPipelineStepStepRequirementModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PipelineStepStepRequirements/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStepStepRequirement>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PipelineStepStepRequirementDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PipelineStepStepRequirements/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPipelineStepStepRequirement> PipelineStepStepRequirementGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepStepRequirements/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPipelineStepStepRequirement>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipelineStepStepRequirement>> PipelineStepStepRequirementAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PipelineStepStepRequirements?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipelineStepStepRequirement>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPipelineStepStepRequirement>> PipelineStepStepRequirementBulkInsertAsync(List<ApiPipelineStepStepRequirementModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PipelineStepStepRequirements/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPipelineStepStepRequirement>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSale> SaleCreateAsync(ApiSaleModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Sales", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSale>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSale> SaleUpdateAsync(int id, ApiSaleModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Sales/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSale>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SaleDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Sales/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSale> SaleGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSale>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSale>> SaleAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSale>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSale>> SaleBulkInsertAsync(List<ApiSaleModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Sales/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSale>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecies> SpeciesCreateAsync(ApiSpeciesModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Species", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecies>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecies> SpeciesUpdateAsync(int id, ApiSpeciesModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Species/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecies>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpeciesDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Species/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSpecies> SpeciesGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Species/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecies>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpecies>> SpeciesAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Species?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpecies>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpecies>> SpeciesBulkInsertAsync(List<ApiSpeciesModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Species/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpecies>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>6040f6a4bcce6e90e40f4f31c6c12ac7</Hash>
</Codenesium>*/