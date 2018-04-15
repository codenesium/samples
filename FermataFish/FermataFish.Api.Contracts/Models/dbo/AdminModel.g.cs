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
			string email,
			string firstName,
			string lastName,
			string phone,
			Nullable<DateTime> birthday,
			int studioId)
		{
			this.Email = email.ToString();
			this.FirstName = firstName.ToString();
			this.LastName = lastName.ToString();
			this.Phone = phone.ToString();
			this.Birthday = birthday.ToNullableDateTime();
			this.StudioId = studioId.ToInt();
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
    <Hash>0f2da4835b4e215d8d365a9c392af7ea</Hash>
</Codenesium>*/