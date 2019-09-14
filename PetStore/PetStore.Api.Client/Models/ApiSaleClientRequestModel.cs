using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Client
{
	public partial class ApiSaleClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSaleClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			decimal amount,
			string firstName,
			string lastName,
			int paymentTypeId,
			int petId,
			string phone)
		{
			this.Amount = amount;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.PaymentTypeId = paymentTypeId;
			this.PetId = petId;
			this.Phone = phone;
		}

		[JsonProperty]
		public decimal Amount { get; private set; } = default(decimal);

		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[JsonProperty]
		public string LastName { get; private set; } = default(string);

		[JsonProperty]
		public int PaymentTypeId { get; private set; }

		[JsonProperty]
		public int PetId { get; private set; }

		[JsonProperty]
		public string Phone { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>97e8f346d410423fa5c26440eda57bac</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/