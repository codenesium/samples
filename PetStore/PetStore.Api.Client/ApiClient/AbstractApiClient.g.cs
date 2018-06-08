using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

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

                public virtual async Task<ApiPaymentTypeResponseModel> PaymentTypeCreateAsync(ApiPaymentTypeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PaymentTypes", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPaymentTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPaymentTypeResponseModel> PaymentTypeUpdateAsync(int id, ApiPaymentTypeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PaymentTypes/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPaymentTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task PaymentTypeDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PaymentTypes/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiPaymentTypeResponseModel> PaymentTypeGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PaymentTypes/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPaymentTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPaymentTypeResponseModel>> PaymentTypeAllAsync(int offset = 0, int limit = 250)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PaymentTypes?offset={offset}&limit={limit}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPaymentTypeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPaymentTypeResponseModel>> PaymentTypeBulkInsertAsync(List<ApiPaymentTypeRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PaymentTypes/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPaymentTypeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPenResponseModel> PenCreateAsync(ApiPenRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pens", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPenResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPenResponseModel> PenUpdateAsync(int id, ApiPenRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Pens/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPenResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task PenDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Pens/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiPenResponseModel> PenGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pens/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPenResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPenResponseModel>> PenAllAsync(int offset = 0, int limit = 250)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pens?offset={offset}&limit={limit}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPenResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPenResponseModel>> PenBulkInsertAsync(List<ApiPenRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pens/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPenResponseModel>>(httpResponse.Content.ContentToString());
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
    <Hash>d0716c3a16454db5dd1233377cd1f513</Hash>
</Codenesium>*/