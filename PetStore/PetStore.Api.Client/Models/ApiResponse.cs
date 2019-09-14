using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStoreNS.Api.Client
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Breeds.ForEach(x => this.AddBreed(x));
			from.PaymentTypes.ForEach(x => this.AddPaymentType(x));
			from.Pens.ForEach(x => this.AddPen(x));
			from.Pets.ForEach(x => this.AddPet(x));
			from.Sales.ForEach(x => this.AddSale(x));
			from.Species.ForEach(x => this.AddSpecies(x));
		}

		public List<ApiBreedClientResponseModel> Breeds { get; private set; } = new List<ApiBreedClientResponseModel>();

		public List<ApiPaymentTypeClientResponseModel> PaymentTypes { get; private set; } = new List<ApiPaymentTypeClientResponseModel>();

		public List<ApiPenClientResponseModel> Pens { get; private set; } = new List<ApiPenClientResponseModel>();

		public List<ApiPetClientResponseModel> Pets { get; private set; } = new List<ApiPetClientResponseModel>();

		public List<ApiSaleClientResponseModel> Sales { get; private set; } = new List<ApiSaleClientResponseModel>();

		public List<ApiSpeciesClientResponseModel> Species { get; private set; } = new List<ApiSpeciesClientResponseModel>();

		public void AddBreed(ApiBreedClientResponseModel item)
		{
			if (!this.Breeds.Any(x => x.Id == item.Id))
			{
				this.Breeds.Add(item);
			}
		}

		public void AddPaymentType(ApiPaymentTypeClientResponseModel item)
		{
			if (!this.PaymentTypes.Any(x => x.Id == item.Id))
			{
				this.PaymentTypes.Add(item);
			}
		}

		public void AddPen(ApiPenClientResponseModel item)
		{
			if (!this.Pens.Any(x => x.Id == item.Id))
			{
				this.Pens.Add(item);
			}
		}

		public void AddPet(ApiPetClientResponseModel item)
		{
			if (!this.Pets.Any(x => x.Id == item.Id))
			{
				this.Pets.Add(item);
			}
		}

		public void AddSale(ApiSaleClientResponseModel item)
		{
			if (!this.Sales.Any(x => x.Id == item.Id))
			{
				this.Sales.Add(item);
			}
		}

		public void AddSpecies(ApiSpeciesClientResponseModel item)
		{
			if (!this.Species.Any(x => x.Id == item.Id))
			{
				this.Species.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>51949bd25039b0ac33c64f215ee6062a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/