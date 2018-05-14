using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiClientModel
	{
		public ApiClientModel()
		{}

		public ApiClientModel(
			string email,
			string firstName,
			string lastName,
			string notes,
			string phone)
		{
			this.Email = email.ToString();
			this.FirstName = firstName.ToString();
			this.LastName = lastName.ToString();
			this.Notes = notes.ToString();
			this.Phone = phone.ToString();
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

		private string notes;

		public string Notes
		{
			get
			{
				return this.notes.IsEmptyOrZeroOrNull() ? null : this.notes;
			}

			set
			{
				this.notes = value;
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
    <Hash>1b85938333fd3c887474d56b20c824aa</Hash>
</Codenesium>*/