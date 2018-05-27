using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiSaleResponseModel: AbstractApiResponseModel
	{
		public ApiSaleResponseModel() : base()
		{}

		public void SetProperties(
			decimal amount,
			int clientId,
			int id,
			string note,
			int petId,
			DateTime saleDate,
			int salesPersonId)
		{
			this.Amount = amount.ToDecimal();
			this.Id = id.ToInt();
			this.Note = note;
			this.SaleDate = saleDate.ToDateTime();
			this.SalesPersonId = salesPersonId.ToInt();

			this.ClientId = new ReferenceEntity<int>(clientId,
			                                         nameof(ApiResponse.Clients));
			this.PetId = new ReferenceEntity<int>(petId,
			                                      nameof(ApiResponse.Pets));
		}

		public decimal Amount { get; set; }
		public ReferenceEntity<int> ClientId { get; set; }
		public int Id { get; set; }
		public string Note { get; set; }
		public ReferenceEntity<int> PetId { get; set; }
		public DateTime SaleDate { get; set; }
		public int SalesPersonId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAmountValue { get; set; } = true;

		public bool ShouldSerializeAmount()
		{
			return this.ShouldSerializeAmountValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeClientIdValue { get; set; } = true;

		public bool ShouldSerializeClientId()
		{
			return this.ShouldSerializeClientIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNoteValue { get; set; } = true;

		public bool ShouldSerializeNote()
		{
			return this.ShouldSerializeNoteValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePetIdValue { get; set; } = true;

		public bool ShouldSerializePetId()
		{
			return this.ShouldSerializePetIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSaleDateValue { get; set; } = true;

		public bool ShouldSerializeSaleDate()
		{
			return this.ShouldSerializeSaleDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesPersonIdValue { get; set; } = true;

		public bool ShouldSerializeSalesPersonId()
		{
			return this.ShouldSerializeSalesPersonIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAmountValue = false;
			this.ShouldSerializeClientIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNoteValue = false;
			this.ShouldSerializePetIdValue = false;
			this.ShouldSerializeSaleDateValue = false;
			this.ShouldSerializeSalesPersonIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>fb4dbc4ce351bb65822a43caa845629d</Hash>
</Codenesium>*/