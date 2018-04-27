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

		public virtual async Task<POCOBreed> BreedCreateAsync(BreedModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Breeds", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBreed>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBreed> BreedUpdateAsync(int id, BreedModel item)
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

		public virtual async Task<List<POCOBreed>> BreedSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Breeds?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBreed>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBreed> BreedGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Breeds/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBreed>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBreed>> BreedGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Breeds?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBreed>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> BreedBulkInsertAsync(List<BreedModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Breeds/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPaymentType> PaymentTypeCreateAsync(PaymentTypeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PaymentTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPaymentType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPaymentType> PaymentTypeUpdateAsync(int id, PaymentTypeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PaymentTypes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPaymentType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PaymentTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PaymentTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOPaymentType>> PaymentTypeSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PaymentTypes?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPaymentType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPaymentType> PaymentTypeGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PaymentTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPaymentType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPaymentType>> PaymentTypeGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PaymentTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPaymentType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> PaymentTypeBulkInsertAsync(List<PaymentTypeModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PaymentTypes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPen> PenCreateAsync(PenModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pens", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPen>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPen> PenUpdateAsync(int id, PenModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Pens/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPen>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PenDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Pens/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOPen>> PenSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pens?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPen>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPen> PenGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pens/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPen>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPen>> PenGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pens?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPen>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> PenBulkInsertAsync(List<PenModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pens/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPet> PetCreateAsync(PetModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pets", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPet>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPet> PetUpdateAsync(int id, PetModel item)
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

		public virtual async Task<List<POCOPet>> PetSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pets?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPet>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPet> PetGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pets/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPet>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPet>> PetGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Pets?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPet>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> PetBulkInsertAsync(List<PetModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Pets/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSale> SaleCreateAsync(SaleModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Sales", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSale>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSale> SaleUpdateAsync(int id, SaleModel item)
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

		public virtual async Task<List<POCOSale>> SaleSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSale>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSale> SaleGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSale>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSale>> SaleGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sales?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSale>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SaleBulkInsertAsync(List<SaleModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Sales/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecies> SpeciesCreateAsync(SpeciesModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Species", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecies>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecies> SpeciesUpdateAsync(int id, SpeciesModel item)
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

		public virtual async Task<List<POCOSpecies>> SpeciesSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Species?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpecies>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecies> SpeciesGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Species/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecies>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpecies>> SpeciesGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Species?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpecies>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SpeciesBulkInsertAsync(List<SpeciesModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Species/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>0040b523e1b18d196d5329021e8426b0</Hash>
</Codenesium>*/