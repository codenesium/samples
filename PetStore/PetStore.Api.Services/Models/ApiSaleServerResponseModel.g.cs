using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Services
{
	public partial class ApiSaleServerResponseModel : AbstractApiServerResponseModel
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
		public string PaymentTypeIdEntity { get; private set; } = RouteConstants.PaymentTypes;

		[JsonProperty]
		public ApiPaymentTypeServerResponseModel PaymentTypeIdNavigation { get; private set; }

		public void SetPaymentTypeIdNavigation(ApiPaymentTypeServerResponseModel value)
		{
			this.PaymentTypeIdNavigation = value;
		}

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
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c2520c59706924b2e7f6c527a7538f4e</Hash>
</Codenesium>*/