using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PetStoreNS.Api.Contracts
{
	public class ReferenceEntity<T>
	{
		[JsonProperty(PropertyName = "Value")]
		public T Value { get; private set; }

		[JsonProperty(PropertyName = "Object")]
		public string ReferenceObjectName { get; set; }

		public ReferenceEntity(T value, string referenceObjectName)
		{
			this.Value = value;
			this.ReferenceObjectName = referenceObjectName;
		}
	}

	public partial class ApiResponse
	{
		public ApiResponse()
		{}

		public void Merge(ApiResponse from)
		{
			from.Breeds.ForEach(x => this.AddBreed(x));
			from.PaymentTypes.ForEach(x => this.AddPaymentType(x));
			from.Pens.ForEach(x => this.AddPen(x));
			from.Pets.ForEach(x => this.AddPet(x));
			from.Sales.ForEach(x => this.AddSale(x));
			from.Species.ForEach(x => this.AddSpecies(x));
		}

		public List<ApiBreedResponseModel> Breeds { get; private set; } = new List<ApiBreedResponseModel>();

		public List<ApiPaymentTypeResponseModel> PaymentTypes { get; private set; } = new List<ApiPaymentTypeResponseModel>();

		public List<ApiPenResponseModel> Pens { get; private set; } = new List<ApiPenResponseModel>();

		public List<ApiPetResponseModel> Pets { get; private set; } = new List<ApiPetResponseModel>();

		public List<ApiSaleResponseModel> Sales { get; private set; } = new List<ApiSaleResponseModel>();

		public List<ApiSpeciesResponseModel> Species { get; private set; } = new List<ApiSpeciesResponseModel>();

		[JsonIgnore]
		public bool ShouldSerializeBreedsValue { get; private set; } = true;

		public bool ShouldSerializeBreeds()
		{
			return this.ShouldSerializeBreedsValue;
		}

		public void AddBreed(ApiBreedResponseModel item)
		{
			if (!this.Breeds.Any(x => x.Id == item.Id))
			{
				this.Breeds.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePaymentTypesValue { get; private set; } = true;

		public bool ShouldSerializePaymentTypes()
		{
			return this.ShouldSerializePaymentTypesValue;
		}

		public void AddPaymentType(ApiPaymentTypeResponseModel item)
		{
			if (!this.PaymentTypes.Any(x => x.Id == item.Id))
			{
				this.PaymentTypes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePensValue { get; private set; } = true;

		public bool ShouldSerializePens()
		{
			return this.ShouldSerializePensValue;
		}

		public void AddPen(ApiPenResponseModel item)
		{
			if (!this.Pens.Any(x => x.Id == item.Id))
			{
				this.Pens.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePetsValue { get; private set; } = true;

		public bool ShouldSerializePets()
		{
			return this.ShouldSerializePetsValue;
		}

		public void AddPet(ApiPetResponseModel item)
		{
			if (!this.Pets.Any(x => x.Id == item.Id))
			{
				this.Pets.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesValue { get; private set; } = true;

		public bool ShouldSerializeSales()
		{
			return this.ShouldSerializeSalesValue;
		}

		public void AddSale(ApiSaleResponseModel item)
		{
			if (!this.Sales.Any(x => x.Id == item.Id))
			{
				this.Sales.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSpeciesValue { get; private set; } = true;

		public bool ShouldSerializeSpecies()
		{
			return this.ShouldSerializeSpeciesValue;
		}

		public void AddSpecies(ApiSpeciesResponseModel item)
		{
			if (!this.Species.Any(x => x.Id == item.Id))
			{
				this.Species.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.Breeds.Count == 0)
			{
				this.ShouldSerializeBreedsValue = false;
			}

			if (this.PaymentTypes.Count == 0)
			{
				this.ShouldSerializePaymentTypesValue = false;
			}

			if (this.Pens.Count == 0)
			{
				this.ShouldSerializePensValue = false;
			}

			if (this.Pets.Count == 0)
			{
				this.ShouldSerializePetsValue = false;
			}

			if (this.Sales.Count == 0)
			{
				this.ShouldSerializeSalesValue = false;
			}

			if (this.Species.Count == 0)
			{
				this.ShouldSerializeSpeciesValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>b975b086c9e08b8d2e2f543ba01c402d</Hash>
</Codenesium>*/