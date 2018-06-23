using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using PetStoreNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
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

                public virtual async Task<ApiBreedResponseModel> BreedCreateAsync(ApiBreedRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Breeds", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBreedResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiBreedResponseModel> BreedUpdateAsync(int id, ApiBreedRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Breeds/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBreedResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task BreedDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Breeds/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiBreedResponseModel> BreedGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Breeds/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBreedResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBreedResponseModel>> BreedAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Breeds?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBreedResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBreedResponseModel>> BreedBulkInsertAsync(List<ApiBreedRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Breeds/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBreedResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPetResponseModel>> Pets(int breedId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Breeds/Pets/{breedId}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPetResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPaymentTypeResponseModel> PaymentTypeCreateAsync(ApiPaymentTypeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PaymentTypes", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPaymentTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPaymentTypeResponseModel> PaymentTypeUpdateAsync(int id, ApiPaymentTypeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PaymentTypes/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPaymentTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task PaymentTypeDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PaymentTypes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiPaymentTypeResponseModel> PaymentTypeGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PaymentTypes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPaymentTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPaymentTypeResponseModel>> PaymentTypeAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PaymentTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPaymentTypeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPaymentTypeResponseModel>> PaymentTypeBulkInsertAsync(List<ApiPaymentTypeRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PaymentTypes/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPaymentTypeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSaleResponseModel>> Sales(int paymentTypeId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PaymentTypes/Sales/{paymentTypeId}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSaleResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPenResponseModel> PenCreateAsync(ApiPenRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pens", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPenResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPenResponseModel> PenUpdateAsync(int id, ApiPenRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Pens/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPenResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task PenDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Pens/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiPenResponseModel> PenGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pens/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPenResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPenResponseModel>> PenAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pens?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPenResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPenResponseModel>> PenBulkInsertAsync(List<ApiPenRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pens/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPenResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPetResponseModel> PetCreateAsync(ApiPetRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pets", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPetResponseModel> PetUpdateAsync(int id, ApiPetRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Pets/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task PetDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Pets/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiPetResponseModel> PetGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pets/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPetResponseModel>> PetAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pets?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPetResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPetResponseModel>> PetBulkInsertAsync(List<ApiPetRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pets/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPetResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSaleResponseModel> SaleCreateAsync(ApiSaleRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Sales", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSaleResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSaleResponseModel> SaleUpdateAsync(int id, ApiSaleRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Sales/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSaleResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SaleDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Sales/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSaleResponseModel> SaleGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSaleResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSaleResponseModel>> SaleAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSaleResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSaleResponseModel>> SaleBulkInsertAsync(List<ApiSaleRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Sales/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSaleResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSpeciesResponseModel> SpeciesCreateAsync(ApiSpeciesRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Species", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpeciesResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSpeciesResponseModel> SpeciesUpdateAsync(int id, ApiSpeciesRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Species/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpeciesResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SpeciesDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Species/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSpeciesResponseModel> SpeciesGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Species/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpeciesResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpeciesResponseModel>> SpeciesAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Species?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpeciesResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpeciesResponseModel>> SpeciesBulkInsertAsync(List<ApiSpeciesRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Species/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpeciesResponseModel>>(httpResponse.Content.ContentToString());
                }
        }
}

/*<Codenesium>
    <Hash>f68cdd1fba68aee74a383a5480e9a0bb</Hash>
</Codenesium>*/