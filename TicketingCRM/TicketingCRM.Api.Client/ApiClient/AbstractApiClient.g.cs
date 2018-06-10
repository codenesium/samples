using Codenesium.DataConversionExtensions.AspNetCore;
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

                public virtual async Task<ApiAdminResponseModel> AdminCreateAsync(ApiAdminRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAdminResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiAdminResponseModel> AdminUpdateAsync(int id, ApiAdminRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Admins/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAdminResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task AdminDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Admins/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiAdminResponseModel> AdminGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAdminResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAdminResponseModel>> AdminAllAsync(int offset = 0, int limit = 250)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins?offset={offset}&limit={limit}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAdminResponseModel>> AdminBulkInsertAsync(List<ApiAdminRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCityResponseModel> CityCreateAsync(ApiCityRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cities", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCityResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCityResponseModel> CityUpdateAsync(int id, ApiCityRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Cities/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCityResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task CityDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Cities/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiCityResponseModel> CityGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cities/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCityResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCityResponseModel>> CityAllAsync(int offset = 0, int limit = 250)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cities?offset={offset}&limit={limit}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCityResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCityResponseModel>> CityBulkInsertAsync(List<ApiCityRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cities/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCityResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCityResponseModel>> GetCityGetProvinceId(int provinceId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cities/getProvinceId/{provinceId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCityResponseModel>>(httpResponse.Content.ContentToString());
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

                public virtual async Task<ApiCustomerResponseModel> CustomerCreateAsync(ApiCustomerRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCustomerResponseModel> CustomerUpdateAsync(int id, ApiCustomerRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Customers/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task CustomerDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Customers/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiCustomerResponseModel> CustomerGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCustomerResponseModel>> CustomerAllAsync(int offset = 0, int limit = 250)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers?offset={offset}&limit={limit}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCustomerResponseModel>> CustomerBulkInsertAsync(List<ApiCustomerRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEventResponseModel> EventCreateAsync(ApiEventRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Events", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEventResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEventResponseModel> EventUpdateAsync(int id, ApiEventRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Events/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEventResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task EventDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Events/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiEventResponseModel> EventGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEventResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventResponseModel>> EventAllAsync(int offset = 0, int limit = 250)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events?offset={offset}&limit={limit}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventResponseModel>> EventBulkInsertAsync(List<ApiEventRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Events/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventResponseModel>> GetEventGetCityId(int cityId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/getCityId/{cityId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProvinceResponseModel> ProvinceCreateAsync(ApiProvinceRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Provinces", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProvinceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProvinceResponseModel> ProvinceUpdateAsync(int id, ApiProvinceRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Provinces/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProvinceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProvinceDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Provinces/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProvinceResponseModel> ProvinceGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Provinces/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProvinceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProvinceResponseModel>> ProvinceAllAsync(int offset = 0, int limit = 250)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Provinces?offset={offset}&limit={limit}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProvinceResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProvinceResponseModel>> ProvinceBulkInsertAsync(List<ApiProvinceRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Provinces/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProvinceResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProvinceResponseModel>> GetProvinceGetCountryId(int countryId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Provinces/getCountryId/{countryId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProvinceResponseModel>>(httpResponse.Content.ContentToString());
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

                public virtual async Task<List<ApiSaleResponseModel>> GetSaleGetTransactionId(int transactionId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales/getTransactionId/{transactionId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSaleResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSaleTicketsResponseModel> SaleTicketsCreateAsync(ApiSaleTicketsRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SaleTickets", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSaleTicketsResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSaleTicketsResponseModel> SaleTicketsUpdateAsync(int id, ApiSaleTicketsRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SaleTickets/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSaleTicketsResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SaleTicketsDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SaleTickets/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSaleTicketsResponseModel> SaleTicketsGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SaleTickets/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSaleTicketsResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSaleTicketsResponseModel>> SaleTicketsAllAsync(int offset = 0, int limit = 250)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SaleTickets?offset={offset}&limit={limit}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSaleTicketsResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSaleTicketsResponseModel>> SaleTicketsBulkInsertAsync(List<ApiSaleTicketsRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SaleTickets/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSaleTicketsResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSaleTicketsResponseModel>> GetSaleTicketsGetTicketId(int ticketId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SaleTickets/getTicketId/{ticketId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSaleTicketsResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTicketResponseModel> TicketCreateAsync(ApiTicketRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tickets", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTicketResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTicketResponseModel> TicketUpdateAsync(int id, ApiTicketRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Tickets/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTicketResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TicketDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Tickets/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTicketResponseModel> TicketGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tickets/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTicketResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTicketResponseModel>> TicketAllAsync(int offset = 0, int limit = 250)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tickets?offset={offset}&limit={limit}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTicketResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTicketResponseModel>> TicketBulkInsertAsync(List<ApiTicketRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tickets/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTicketResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTicketResponseModel>> GetTicketGetTicketStatusId(int ticketStatusId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tickets/getTicketStatusId/{ticketStatusId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTicketResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTicketStatusResponseModel> TicketStatusCreateAsync(ApiTicketStatusRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TicketStatus", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTicketStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTicketStatusResponseModel> TicketStatusUpdateAsync(int id, ApiTicketStatusRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TicketStatus/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTicketStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TicketStatusDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TicketStatus/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTicketStatusResponseModel> TicketStatusGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TicketStatus/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTicketStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTicketStatusResponseModel>> TicketStatusAllAsync(int offset = 0, int limit = 250)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TicketStatus?offset={offset}&limit={limit}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTicketStatusResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTicketStatusResponseModel>> TicketStatusBulkInsertAsync(List<ApiTicketStatusRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TicketStatus/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTicketStatusResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTransactionResponseModel> TransactionCreateAsync(ApiTransactionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Transactions", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTransactionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTransactionResponseModel> TransactionUpdateAsync(int id, ApiTransactionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Transactions/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTransactionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TransactionDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Transactions/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTransactionResponseModel> TransactionGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Transactions/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTransactionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionResponseModel>> TransactionAllAsync(int offset = 0, int limit = 250)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Transactions?offset={offset}&limit={limit}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionResponseModel>> TransactionBulkInsertAsync(List<ApiTransactionRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Transactions/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionResponseModel>> GetTransactionGetTransactionStatusId(int transactionStatusId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Transactions/getTransactionStatusId/{transactionStatusId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTransactionStatusResponseModel> TransactionStatusCreateAsync(ApiTransactionStatusRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionStatus", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTransactionStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTransactionStatusResponseModel> TransactionStatusUpdateAsync(int id, ApiTransactionStatusRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TransactionStatus/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTransactionStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TransactionStatusDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TransactionStatus/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTransactionStatusResponseModel> TransactionStatusGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionStatus/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTransactionStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionStatusResponseModel>> TransactionStatusAllAsync(int offset = 0, int limit = 250)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionStatus?offset={offset}&limit={limit}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionStatusResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionStatusResponseModel>> TransactionStatusBulkInsertAsync(List<ApiTransactionStatusRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionStatus/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionStatusResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiVenueResponseModel> VenueCreateAsync(ApiVenueRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Venues", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVenueResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiVenueResponseModel> VenueUpdateAsync(int id, ApiVenueRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Venues/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVenueResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task VenueDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Venues/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiVenueResponseModel> VenueGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Venues/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVenueResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiVenueResponseModel>> VenueAllAsync(int offset = 0, int limit = 250)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Venues?offset={offset}&limit={limit}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiVenueResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiVenueResponseModel>> VenueBulkInsertAsync(List<ApiVenueRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Venues/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiVenueResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiVenueResponseModel>> GetVenueGetAdminId(int adminId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Venues/getAdminId/{adminId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiVenueResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiVenueResponseModel>> GetVenueGetProvinceId(int provinceId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Venues/getProvinceId/{provinceId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiVenueResponseModel>>(httpResponse.Content.ContentToString());
                }
        }
}

/*<Codenesium>
    <Hash>29f3a9d3439b343e6d395edde5dde712</Hash>
</Codenesium>*/