using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PetStoreNS.Api.Contracts
{
	public class ReferenceEntity<T>
	{
		[JsonProperty(PropertyName = "V")]
		public T Value { get; set; }

		[JsonProperty(PropertyName = "O")]
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

		public List<POCOBreed> Breeds { get; private set; } = new List<POCOBreed>();

		public List<POCOPaymentType> PaymentTypes { get; private set; } = new List<POCOPaymentType>();

		public List<POCOPen> Pens { get; private set; } = new List<POCOPen>();

		public List<POCOPet> Pets { get; private set; } = new List<POCOPet>();

		public List<POCOSale> Sales { get; private set; } = new List<POCOSale>();

		public List<POCOSpecies> Species { get; private set; } = new List<POCOSpecies>();

		[JsonIgnore]
		public bool ShouldSerializeBreedsValue { get; set; } = true;

		public bool ShouldSerializeBreeds()
		{
			return this.ShouldSerializeBreedsValue;
		}

		public void AddBreed(POCOBreed item)
		{
			if (!this.Breeds.Any(x => x.Id == item.Id))
			{
				this.Breeds.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePaymentTypesValue { get; set; } = true;

		public bool ShouldSerializePaymentTypes()
		{
			return this.ShouldSerializePaymentTypesValue;
		}

		public void AddPaymentType(POCOPaymentType item)
		{
			if (!this.PaymentTypes.Any(x => x.Id == item.Id))
			{
				this.PaymentTypes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePensValue { get; set; } = true;

		public bool ShouldSerializePens()
		{
			return this.ShouldSerializePensValue;
		}

		public void AddPen(POCOPen item)
		{
			if (!this.Pens.Any(x => x.Id == item.Id))
			{
				this.Pens.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePetsValue { get; set; } = true;

		public bool ShouldSerializePets()
		{
			return this.ShouldSerializePetsValue;
		}

		public void AddPet(POCOPet item)
		{
			if (!this.Pets.Any(x => x.Id == item.Id))
			{
				this.Pets.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesValue { get; set; } = true;

		public bool ShouldSerializeSales()
		{
			return this.ShouldSerializeSalesValue;
		}

		public void AddSale(POCOSale item)
		{
			if (!this.Sales.Any(x => x.Id == item.Id))
			{
				this.Sales.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSpeciesValue { get; set; } = true;

		public bool ShouldSerializeSpecies()
		{
			return this.ShouldSerializeSpeciesValue;
		}

		public void AddSpecies(POCOSpecies item)
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
    <Hash>7a1f5986c70e209b4c3cab0fa0aede32</Hash>
</Codenesium>*/