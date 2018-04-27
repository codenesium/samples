using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class AdminModel
	{
		public AdminModel()
		{}

		public AdminModel(
			Nullable<DateTime> birthday,
			string email,
			string firstName,
			string lastName,
			string phone,
			int studioId)
		{
			this.Birthday = birthday.ToNullableDateTime();
			this.Email = email.ToString();
			this.FirstName = firstName.ToString();
			this.LastName = lastName.ToString();
			this.Phone = phone.ToString();
			this.StudioId = studioId.ToInt();
		}

		private Nullable<DateTime> birthday;

		public Nullable<DateTime> Birthday
		{
			get
			{
				return this.birthday.IsEmptyOrZeroOrNull() ? null : this.birthday;
			}

			set
			{
				this.birthday = value;
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

		private int studioId;

		[Required]
		public int StudioId
		{
			get
			{
				return this.studioId;
			}

			set
			{
				this.studioId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>18430c63e40c0244b67080855bf7c9a3</Hash>
</Codenesium>*/