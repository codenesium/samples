using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Services
{
	public partial class ApiSaleServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSaleServerRequestModel()
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

		[Required]
		[JsonProperty]
		public decimal Amount { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string LastName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int PaymentTypeId { get; private set; }

		[Required]
		[JsonProperty]
		public int PetId { get; private set; }

		[Required]
		[JsonProperty]
		public string Phone { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>ac2321d9ca89252a965325ae21db40fa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/