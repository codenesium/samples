using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using PetStoreNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public abstract class AbstractApiClient
	{
		protected HttpClient Client { get; private set; }

		protected string ApiUrl { get; set; }

		protected string ApiVersion { get; set; }

		protected int MaxLimit { get; set; } = 1000;

		public AbstractApiClient(HttpClient client)
		{
			this.Client = client;
		}

		public AbstractApiClient(string apiUrl, string apiVersion = "1.0")
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
			this.Client = new HttpClient();
			this.Client.BaseAddress = new Uri(apiUrl);
			this.Client.DefaultRequestHeaders.Accept.Clear();
			this.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			this.Client.DefaultRequestHeaders.Add("api-version", this.ApiVersion);
		}

		public void SetBearerToken(string token)
		{
			this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}

		public virtual async Task<CreateResponse<List<ApiBreedClientResponseModel>>> BreedBulkInsertAsync(List<ApiBreedClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Breeds/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiBreedClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiBreedClientResponseModel>> BreedCreateAsync(ApiBreedClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Breeds", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiBreedClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiBreedClientResponseModel>> BreedUpdateAsync(int id, ApiBreedClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Breeds/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiBreedClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> BreedDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Breeds/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBreedClientResponseModel> BreedGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Breeds/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiBreedClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBreedClientResponseModel>> BreedAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiBreedClientResponseModel> response = new List<ApiBreedClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Breeds?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiBreedClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiBreedClientResponseModel>>(httpResponse.Content.ContentToString());
				response.AddRange(records);
				if (records.Count < this.MaxLimit)
				{
					moreRecords = false;
				}
				else
				{
					offset += this.MaxLimit;
				}
			}

			return response;
		}

		public virtual async Task<List<ApiPetClientResponseModel>> PetsByBreedId(int breedId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Breeds/{breedId}/Pets", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiPetClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiPaymentTypeClientResponseModel>>> PaymentTypeBulkInsertAsync(List<ApiPaymentTypeClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/PaymentTypes/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiPaymentTypeClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPaymentTypeClientResponseModel>> PaymentTypeCreateAsync(ApiPaymentTypeClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/PaymentTypes", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiPaymentTypeClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPaymentTypeClientResponseModel>> PaymentTypeUpdateAsync(int id, ApiPaymentTypeClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/PaymentTypes/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiPaymentTypeClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PaymentTypeDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/PaymentTypes/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPaymentTypeClientResponseModel> PaymentTypeGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/PaymentTypes/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiPaymentTypeClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPaymentTypeClientResponseModel>> PaymentTypeAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiPaymentTypeClientResponseModel> response = new List<ApiPaymentTypeClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/PaymentTypes?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiPaymentTypeClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiPaymentTypeClientResponseModel>>(httpResponse.Content.ContentToString());
				response.AddRange(records);
				if (records.Count < this.MaxLimit)
				{
					moreRecords = false;
				}
				else
				{
					offset += this.MaxLimit;
				}
			}

			return response;
		}

		public virtual async Task<List<ApiSaleClientResponseModel>> SalesByPaymentTypeId(int paymentTypeId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/PaymentTypes/{paymentTypeId}/Sales", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiSaleClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiPenClientResponseModel>>> PenBulkInsertAsync(List<ApiPenClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Pens/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiPenClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPenClientResponseModel>> PenCreateAsync(ApiPenClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Pens", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiPenClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPenClientResponseModel>> PenUpdateAsync(int id, ApiPenClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Pens/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiPenClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PenDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Pens/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPenClientResponseModel> PenGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Pens/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiPenClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPenClientResponseModel>> PenAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiPenClientResponseModel> response = new List<ApiPenClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Pens?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiPenClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiPenClientResponseModel>>(httpResponse.Content.ContentToString());
				response.AddRange(records);
				if (records.Count < this.MaxLimit)
				{
					moreRecords = false;
				}
				else
				{
					offset += this.MaxLimit;
				}
			}

			return response;
		}

		public virtual async Task<List<ApiPetClientResponseModel>> PetsByPenId(int penId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Pens/{penId}/Pets", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiPetClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiPetClientResponseModel>>> PetBulkInsertAsync(List<ApiPetClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Pets/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiPetClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPetClientResponseModel>> PetCreateAsync(ApiPetClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Pets", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiPetClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPetClientResponseModel>> PetUpdateAsync(int id, ApiPetClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Pets/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiPetClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PetDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Pets/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPetClientResponseModel> PetGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Pets/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiPetClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPetClientResponseModel>> PetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiPetClientResponseModel> response = new List<ApiPetClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Pets?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiPetClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiPetClientResponseModel>>(httpResponse.Content.ContentToString());
				response.AddRange(records);
				if (records.Count < this.MaxLimit)
				{
					moreRecords = false;
				}
				else
				{
					offset += this.MaxLimit;
				}
			}

			return response;
		}

		public virtual async Task<List<ApiSaleClientResponseModel>> SalesByPetId(int petId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Pets/{petId}/Sales", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiSaleClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiSaleClientResponseModel>>> SaleBulkInsertAsync(List<ApiSaleClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Sales/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiSaleClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSaleClientResponseModel>> SaleCreateAsync(ApiSaleClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Sales", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiSaleClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSaleClientResponseModel>> SaleUpdateAsync(int id, ApiSaleClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Sales/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiSaleClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SaleDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Sales/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSaleClientResponseModel> SaleGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Sales/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiSaleClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSaleClientResponseModel>> SaleAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiSaleClientResponseModel> response = new List<ApiSaleClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Sales?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiSaleClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiSaleClientResponseModel>>(httpResponse.Content.ContentToString());
				response.AddRange(records);
				if (records.Count < this.MaxLimit)
				{
					moreRecords = false;
				}
				else
				{
					offset += this.MaxLimit;
				}
			}

			return response;
		}

		public virtual async Task<CreateResponse<List<ApiSpeciesClientResponseModel>>> SpeciesBulkInsertAsync(List<ApiSpeciesClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Species/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiSpeciesClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSpeciesClientResponseModel>> SpeciesCreateAsync(ApiSpeciesClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Species", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiSpeciesClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSpeciesClientResponseModel>> SpeciesUpdateAsync(int id, ApiSpeciesClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Species/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiSpeciesClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SpeciesDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Species/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpeciesClientResponseModel> SpeciesGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Species/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiSpeciesClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpeciesClientResponseModel>> SpeciesAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiSpeciesClientResponseModel> response = new List<ApiSpeciesClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Species?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiSpeciesClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiSpeciesClientResponseModel>>(httpResponse.Content.ContentToString());
				response.AddRange(records);
				if (records.Count < this.MaxLimit)
				{
					moreRecords = false;
				}
				else
				{
					offset += this.MaxLimit;
				}
			}

			return response;
		}

		public virtual async Task<List<ApiPetClientResponseModel>> PetsBySpeciesId(int speciesId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Species/{speciesId}/Pets", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiPetClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		protected void HandleResponseCode(HttpResponseMessage httpResponse)
		{
			int responseCode = (int)httpResponse.StatusCode;
			if (responseCode >= 400 && responseCode != 422)
			{
				switch (responseCode)
				{
				case 401:
				{
					throw new UnauthorizedAccessException("Response from server was 401.");
				}

				case 404:
				{
					break;
				}

				default:
				{
					throw new Exception($"Received error response from server. Response code was {responseCode}. Message was {httpResponse.Content.ContentToString()}");
				}
				}
			}
		}
	}
}

/*<Codenesium>
    <Hash>2f3bc2fe9e255bdfe0a4ff2a30d33181</Hash>
</Codenesium>*/