using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiSaleServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			decimal amount,
			int cutomerId,
			string note,
			int petId,
			DateTime saleDate,
			int salesPersonId)
		{
			this.Id = id;
			this.Amount = amount;
			this.CutomerId = cutomerId;
			this.Note = note;
			this.PetId = petId;
			this.SaleDate = saleDate;
			this.SalesPersonId = salesPersonId;
		}

		[JsonProperty]
		public decimal Amount { get; private set; }

		[JsonProperty]
		public int CutomerId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Note { get; private set; }

		[JsonProperty]
		public int PetId { get; private set; }

		[JsonProperty]
		public string PetIdEntity { get; private set; } = RouteConstants.Pets;

		[JsonProperty]
		public ApiPetServerResponseModel PetIdNavigation { get; private set; }

		public void SetPetIdNavigation(ApiPetServerResponseModel value)
		{
			this.PetIdNavigation = value;
		}

		[JsonProperty]
		public DateTime SaleDate { get; private set; }

		[JsonProperty]
		public int SalesPersonId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5aa9a143c7729594a11e0c6704b74921</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/