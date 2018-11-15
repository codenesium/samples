using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Client
{
	public partial class ApiSaleClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			decimal amount,
			string firstName,
			string lastName,
			int paymentTypeId,
			int petId,
			string phone)
		{
			this.Id = id;
			this.Amount = amount;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.PaymentTypeId = paymentTypeId;
			this.PetId = petId;
			this.Phone = phone;

			this.PaymentTypeIdEntity = nameof(ApiResponse.PaymentTypes);
			this.PetIdEntity = nameof(ApiResponse.Pets);
		}

		[JsonProperty]
		public decimal Amount { get; private set; }

		[JsonProperty]
		public string FirstName { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string LastName { get; private set; }

		[JsonProperty]
		public int PaymentTypeId { get; private set; }

		[JsonProperty]
		public string PaymentTypeIdEntity { get; set; }

		[JsonProperty]
		public int PetId { get; private set; }

		[JsonProperty]
		public string PetIdEntity { get; set; }

		[JsonProperty]
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b1b48a2ce3652ab846832467aca15315</Hash>
</Codenesium>*/