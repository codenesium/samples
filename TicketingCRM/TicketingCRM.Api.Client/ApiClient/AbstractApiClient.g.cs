using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
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

		public virtual async Task<CreateResponse<ApiAdminResponseModel>> AdminCreateAsync(ApiAdminRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiAdminResponseModel>> AdminUpdateAsync(int id, ApiAdminRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Admins/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> AdminDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Admins/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAdminResponseModel> AdminGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiAdminResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAdminResponseModel>> AdminAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAdminResponseModel>> AdminBulkInsertAsync(List<ApiAdminRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVenueResponseModel>> Venues(int adminId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins/Venues/{adminId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVenueResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCityResponseModel>> CityCreateAsync(ApiCityRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cities", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCityResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCityResponseModel>> CityUpdateAsync(int id, ApiCityRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Cities/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCityResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CityDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Cities/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCityResponseModel> CityGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cities/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCityResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCityResponseModel>> CityAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cities?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCityResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCityResponseModel>> CityBulkInsertAsync(List<ApiCityRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cities/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCityResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCityResponseModel>> GetCityByProvinceId(int provinceId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cities/byProvinceId/{provinceId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCityResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventResponseModel>> Events(int cityId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cities/Events/{cityId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiProvinceResponseModel>> Provinces(int countryId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Countries/Provinces/{countryId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProvinceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCustomerResponseModel>> CustomerCreateAsync(ApiCustomerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCustomerResponseModel>> CustomerUpdateAsync(int id, ApiCustomerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Customers/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CustomerDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Customers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCustomerResponseModel> CustomerGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCustomerResponseModel>> CustomerAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCustomerResponseModel>> CustomerBulkInsertAsync(List<ApiCustomerRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiEventResponseModel>> EventCreateAsync(ApiEventRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Events", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiEventResponseModel>> EventUpdateAsync(int id, ApiEventRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Events/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> EventDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Events/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEventResponseModel> EventGetAsync(int id)
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

		public virtual async Task<List<ApiEventResponseModel>> GetEventByCityId(int cityId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/byCityId/{cityId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProvinceResponseModel>> ProvinceCreateAsync(ApiProvinceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Provinces", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProvinceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProvinceResponseModel>> ProvinceUpdateAsync(int id, ApiProvinceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Provinces/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProvinceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProvinceDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Provinces/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProvinceResponseModel> ProvinceGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Provinces/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProvinceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProvinceResponseModel>> ProvinceAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Provinces?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProvinceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProvinceResponseModel>> ProvinceBulkInsertAsync(List<ApiProvinceRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Provinces/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProvinceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProvinceResponseModel>> GetProvinceByCountryId(int countryId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Provinces/byCountryId/{countryId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProvinceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCityResponseModel>> Cities(int provinceId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Provinces/Cities/{provinceId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCityResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiSaleResponseModel>> GetSaleByTransactionId(int transactionId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales/byTransactionId/{transactionId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSaleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSaleTicketsResponseModel>> SaleTickets(int saleId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales/SaleTickets/{saleId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSaleTicketsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSaleTicketsResponseModel>> SaleTicketsCreateAsync(ApiSaleTicketsRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SaleTickets", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSaleTicketsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSaleTicketsResponseModel>> SaleTicketsUpdateAsync(int id, ApiSaleTicketsRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SaleTickets/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSaleTicketsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SaleTicketsDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SaleTickets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSaleTicketsResponseModel> SaleTicketsGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SaleTickets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSaleTicketsResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSaleTicketsResponseModel>> SaleTicketsAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SaleTickets?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSaleTicketsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSaleTicketsResponseModel>> SaleTicketsBulkInsertAsync(List<ApiSaleTicketsRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SaleTickets/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSaleTicketsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSaleTicketsResponseModel>> GetSaleTicketsByTicketId(int ticketId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SaleTickets/byTicketId/{ticketId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSaleTicketsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTicketResponseModel>> TicketCreateAsync(ApiTicketRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tickets", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTicketResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTicketResponseModel>> TicketUpdateAsync(int id, ApiTicketRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Tickets/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTicketResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TicketDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Tickets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTicketResponseModel> TicketGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tickets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTicketResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTicketResponseModel>> TicketAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tickets?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTicketResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTicketResponseModel>> TicketBulkInsertAsync(List<ApiTicketRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tickets/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTicketResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTicketResponseModel>> GetTicketByTicketStatusId(int ticketStatusId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tickets/byTicketStatusId/{ticketStatusId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTicketResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTicketStatusResponseModel>> TicketStatusCreateAsync(ApiTicketStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TicketStatus", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTicketStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTicketStatusResponseModel>> TicketStatusUpdateAsync(int id, ApiTicketStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TicketStatus/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTicketStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TicketStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TicketStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTicketStatusResponseModel> TicketStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TicketStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTicketStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTicketStatusResponseModel>> TicketStatusAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TicketStatus?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTicketStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTicketStatusResponseModel>> TicketStatusBulkInsertAsync(List<ApiTicketStatusRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TicketStatus/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTicketStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTicketResponseModel>> Tickets(int ticketStatusId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TicketStatus/Tickets/{ticketStatusId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTicketResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTransactionResponseModel>> TransactionCreateAsync(ApiTransactionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Transactions", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTransactionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTransactionResponseModel>> TransactionUpdateAsync(int id, ApiTransactionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Transactions/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTransactionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TransactionDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Transactions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTransactionResponseModel> TransactionGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Transactions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTransactionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionResponseModel>> TransactionAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Transactions?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionResponseModel>> TransactionBulkInsertAsync(List<ApiTransactionRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Transactions/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionResponseModel>> GetTransactionByTransactionStatusId(int transactionStatusId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Transactions/byTransactionStatusId/{transactionStatusId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSaleResponseModel>> Sales(int transactionId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Transactions/Sales/{transactionId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSaleResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTransactionStatusResponseModel>> TransactionStatusCreateAsync(ApiTransactionStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionStatus", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTransactionStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTransactionStatusResponseModel>> TransactionStatusUpdateAsync(int id, ApiTransactionStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TransactionStatus/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTransactionStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TransactionStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TransactionStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTransactionStatusResponseModel> TransactionStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTransactionStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionStatusResponseModel>> TransactionStatusAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionStatus?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionStatusResponseModel>> TransactionStatusBulkInsertAsync(List<ApiTransactionStatusRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionStatus/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionResponseModel>> Transactions(int transactionStatusId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionStatus/Transactions/{transactionStatusId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiVenueResponseModel>> VenueCreateAsync(ApiVenueRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Venues", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiVenueResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiVenueResponseModel>> VenueUpdateAsync(int id, ApiVenueRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Venues/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiVenueResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> VenueDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Venues/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVenueResponseModel> VenueGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Venues/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVenueResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVenueResponseModel>> VenueAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Venues?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVenueResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVenueResponseModel>> VenueBulkInsertAsync(List<ApiVenueRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Venues/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVenueResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVenueResponseModel>> GetVenueByAdminId(int adminId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Venues/byAdminId/{adminId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVenueResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVenueResponseModel>> GetVenueByProvinceId(int provinceId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Venues/byProvinceId/{provinceId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVenueResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>e2a4fec6b30c0469c0b514a271ffe22f</Hash>
</Codenesium>*/