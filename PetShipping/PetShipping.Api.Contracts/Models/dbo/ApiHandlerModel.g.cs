using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiHandlerModel: AbstractModel
	{
		public ApiHandlerModel() : base()
		{}

		public ApiHandlerModel(
			int countryId,
			string email,
			string firstName,
			string lastName,
			string phone)
		{
			this.CountryId = countryId.ToInt();
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
		}

		private int countryId;

		[Required]
		public int CountryId
		{
			get
			{
				return this.countryId;
			}

			set
			{
				this.countryId = value;
			}
		}

		private string email;

		[Required]
		public string Email
		{
			get
			{
				return this.email;
			}

			set
			{
				this.email = value;
			}
		}

		private string firstName;

		[Required]
		public string FirstName
		{
			get
			{
				return this.firstName;
			}

			set
			{
				this.firstName = value;
			}
		}

		private string lastName;

		[Required]
		public string LastName
		{
			get
			{
				return this.lastName;
			}

			set
			{
				this.lastName = value;
			}
		}

		private string phone;

		[Required]
		public string Phone
		{
			get
			{
				return this.phone;
			}

			set
			{
				this.phone = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>0e3783a248e25052a10d068df17bd88a</Hash>
</Codenesium>*/