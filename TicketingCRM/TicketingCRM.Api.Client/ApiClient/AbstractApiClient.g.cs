using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
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

		public virtual async Task<CreateResponse<List<ApiAdminClientResponseModel>>> AdminBulkInsertAsync(List<ApiAdminClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Admins/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiAdminClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiAdminClientResponseModel>> AdminCreateAsync(ApiAdminClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Admins", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiAdminClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiAdminClientResponseModel>> AdminUpdateAsync(int id, ApiAdminClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Admins/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiAdminClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> AdminDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Admins/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAdminClientResponseModel> AdminGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Admins/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiAdminClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAdminClientResponseModel>> AdminAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiAdminClientResponseModel> response = new List<ApiAdminClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Admins?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiAdminClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiAdminClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiVenueClientResponseModel>> VenuesByAdminId(int adminId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Admins/{adminId}/Venues", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiVenueClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiCityClientResponseModel>>> CityBulkInsertAsync(List<ApiCityClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Cities/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiCityClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCityClientResponseModel>> CityCreateAsync(ApiCityClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Cities", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiCityClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCityClientResponseModel>> CityUpdateAsync(int id, ApiCityClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Cities/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiCityClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CityDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Cities/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCityClientResponseModel> CityGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Cities/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiCityClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCityClientResponseModel>> CityAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiCityClientResponseModel> response = new List<ApiCityClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Cities?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiCityClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiCityClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiCityClientResponseModel>> ByCityByProvinceId(int provinceId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Cities/byProvinceId/{provinceId}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiCityClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventClientResponseModel>> EventsByCityId(int cityId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Cities/{cityId}/Events", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiEventClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiCountryClientResponseModel>>> CountryBulkInsertAsync(List<ApiCountryClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Countries/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiCountryClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCountryClientResponseModel>> CountryCreateAsync(ApiCountryClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Countries", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiCountryClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCountryClientResponseModel>> CountryUpdateAsync(int id, ApiCountryClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Countries/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiCountryClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CountryDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Countries/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryClientResponseModel> CountryGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Countries/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiCountryClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryClientResponseModel>> CountryAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiCountryClientResponseModel> response = new List<ApiCountryClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Countries?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiCountryClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiCountryClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiProvinceClientResponseModel>> ProvincesByCountryId(int countryId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Countries/{countryId}/Provinces", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiProvinceClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiCustomerClientResponseModel>>> CustomerBulkInsertAsync(List<ApiCustomerClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Customers/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiCustomerClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCustomerClientResponseModel>> CustomerCreateAsync(ApiCustomerClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Customers", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiCustomerClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCustomerClientResponseModel>> CustomerUpdateAsync(int id, ApiCustomerClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Customers/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiCustomerClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CustomerDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Customers/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCustomerClientResponseModel> CustomerGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Customers/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiCustomerClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCustomerClientResponseModel>> CustomerAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiCustomerClientResponseModel> response = new List<ApiCustomerClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Customers?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiCustomerClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiCustomerClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<CreateResponse<List<ApiEventClientResponseModel>>> EventBulkInsertAsync(List<ApiEventClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Events/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiEventClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiEventClientResponseModel>> EventCreateAsync(ApiEventClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Events", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiEventClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiEventClientResponseModel>> EventUpdateAsync(int id, ApiEventClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Events/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiEventClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> EventDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Events/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEventClientResponseModel> EventGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Events/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiEventClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventClientResponseModel>> EventAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiEventClientResponseModel> response = new List<ApiEventClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Events?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiEventClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiEventClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiEventClientResponseModel>> ByEventByCityId(int cityId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Events/byCityId/{cityId}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiEventClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiProvinceClientResponseModel>>> ProvinceBulkInsertAsync(List<ApiProvinceClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Provinces/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiProvinceClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProvinceClientResponseModel>> ProvinceCreateAsync(ApiProvinceClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Provinces", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiProvinceClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProvinceClientResponseModel>> ProvinceUpdateAsync(int id, ApiProvinceClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Provinces/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiProvinceClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProvinceDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Provinces/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProvinceClientResponseModel> ProvinceGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Provinces/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiProvinceClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProvinceClientResponseModel>> ProvinceAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiProvinceClientResponseModel> response = new List<ApiProvinceClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Provinces?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiProvinceClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiProvinceClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiProvinceClientResponseModel>> ByProvinceByCountryId(int countryId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Provinces/byCountryId/{countryId}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiProvinceClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCityClientResponseModel>> CitiesByProvinceId(int provinceId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Provinces/{provinceId}/Cities", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiCityClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVenueClientResponseModel>> VenuesByProvinceId(int provinceId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Provinces/{provinceId}/Venues", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiVenueClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiSaleClientResponseModel>> BySaleByTransactionId(int transactionId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Sales/byTransactionId/{transactionId}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiSaleClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiTicketClientResponseModel>>> TicketBulkInsertAsync(List<ApiTicketClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Tickets/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiTicketClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTicketClientResponseModel>> TicketCreateAsync(ApiTicketClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Tickets", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiTicketClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTicketClientResponseModel>> TicketUpdateAsync(int id, ApiTicketClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Tickets/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiTicketClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TicketDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Tickets/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTicketClientResponseModel> TicketGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Tickets/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiTicketClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTicketClientResponseModel>> TicketAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiTicketClientResponseModel> response = new List<ApiTicketClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Tickets?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiTicketClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiTicketClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiTicketClientResponseModel>> ByTicketByTicketStatusId(int ticketStatusId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Tickets/byTicketStatusId/{ticketStatusId}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiTicketClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiTicketStatuClientResponseModel>>> TicketStatuBulkInsertAsync(List<ApiTicketStatuClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/TicketStatus/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiTicketStatuClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTicketStatuClientResponseModel>> TicketStatuCreateAsync(ApiTicketStatuClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/TicketStatus", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiTicketStatuClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTicketStatuClientResponseModel>> TicketStatuUpdateAsync(int id, ApiTicketStatuClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/TicketStatus/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiTicketStatuClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TicketStatuDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/TicketStatus/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTicketStatuClientResponseModel> TicketStatuGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/TicketStatus/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiTicketStatuClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTicketStatuClientResponseModel>> TicketStatuAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiTicketStatuClientResponseModel> response = new List<ApiTicketStatuClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/TicketStatus?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiTicketStatuClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiTicketStatuClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiTicketClientResponseModel>> TicketsByTicketStatusId(int ticketStatusId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/TicketStatus/{ticketStatusId}/Tickets", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiTicketClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiTransactionClientResponseModel>>> TransactionBulkInsertAsync(List<ApiTransactionClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Transactions/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiTransactionClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTransactionClientResponseModel>> TransactionCreateAsync(ApiTransactionClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Transactions", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiTransactionClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTransactionClientResponseModel>> TransactionUpdateAsync(int id, ApiTransactionClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Transactions/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiTransactionClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TransactionDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Transactions/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTransactionClientResponseModel> TransactionGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Transactions/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiTransactionClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionClientResponseModel>> TransactionAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiTransactionClientResponseModel> response = new List<ApiTransactionClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Transactions?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiTransactionClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiTransactionClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiTransactionClientResponseModel>> ByTransactionByTransactionStatusId(int transactionStatusId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Transactions/byTransactionStatusId/{transactionStatusId}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiTransactionClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSaleClientResponseModel>> SalesByTransactionId(int transactionId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Transactions/{transactionId}/Sales", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiSaleClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiTransactionStatuClientResponseModel>>> TransactionStatuBulkInsertAsync(List<ApiTransactionStatuClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/TransactionStatus/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiTransactionStatuClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTransactionStatuClientResponseModel>> TransactionStatuCreateAsync(ApiTransactionStatuClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/TransactionStatus", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiTransactionStatuClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTransactionStatuClientResponseModel>> TransactionStatuUpdateAsync(int id, ApiTransactionStatuClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/TransactionStatus/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiTransactionStatuClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TransactionStatuDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/TransactionStatus/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTransactionStatuClientResponseModel> TransactionStatuGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/TransactionStatus/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiTransactionStatuClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionStatuClientResponseModel>> TransactionStatuAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiTransactionStatuClientResponseModel> response = new List<ApiTransactionStatuClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/TransactionStatus?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiTransactionStatuClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiTransactionStatuClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiTransactionClientResponseModel>> TransactionsByTransactionStatusId(int transactionStatusId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/TransactionStatus/{transactionStatusId}/Transactions", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiTransactionClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiVenueClientResponseModel>>> VenueBulkInsertAsync(List<ApiVenueClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Venues/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiVenueClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiVenueClientResponseModel>> VenueCreateAsync(ApiVenueClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Venues", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiVenueClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiVenueClientResponseModel>> VenueUpdateAsync(int id, ApiVenueClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Venues/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiVenueClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> VenueDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Venues/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVenueClientResponseModel> VenueGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Venues/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiVenueClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVenueClientResponseModel>> VenueAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiVenueClientResponseModel> response = new List<ApiVenueClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Venues?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiVenueClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiVenueClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiVenueClientResponseModel>> ByVenueByAdminId(int adminId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Venues/byAdminId/{adminId}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiVenueClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVenueClientResponseModel>> ByVenueByProvinceId(int provinceId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Venues/byProvinceId/{provinceId}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiVenueClientResponseModel>>(httpResponse.Content.ContentToString());
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
    <Hash>47c38dae12f98b43a178f14b5b85ac5a</Hash>
</Codenesium>*/