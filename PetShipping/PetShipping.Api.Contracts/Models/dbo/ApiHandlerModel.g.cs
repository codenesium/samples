using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiHandlerModel
	{
		public ApiHandlerModel()
		{}

		public ApiHandlerModel(
			int countryId,
			string email,
			string firstName,
			string lastName,
			string phone)
		{
			this.CountryId = countryId.ToInt();
			this.Email = email.ToString();
			this.FirstName = firstName.ToString();
			this.LastName = lastName.ToString();
			this.Phone = phone.ToString();
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
    <Hash>38d19f8f6ddeaade3622d0f090c3c057</Hash>
</Codenesium>*/