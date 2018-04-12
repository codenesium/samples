using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class PersonModel
	{
		public PersonModel()
		{}

		public PersonModel(
			string personType,
			bool nameStyle,
			string title,
			string firstName,
			string middleName,
			string lastName,
			string suffix,
			int emailPromotion,
			string additionalContactInfo,
			string demographics,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.PersonType = personType;
			this.NameStyle = nameStyle;
			this.Title = title;
			this.FirstName = firstName;
			this.MiddleName = middleName;
			this.LastName = lastName;
			this.Suffix = suffix;
			this.EmailPromotion = emailPromotion.ToInt();
			this.AdditionalContactInfo = additionalContactInfo;
			this.Demographics = demographics;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string personType;

		[Required]
		public string PersonType
		{
			get
			{
				return this.personType;
			}

			set
			{
				this.personType = value;
			}
		}

		private bool nameStyle;

		[Required]
		public bool NameStyle
		{
			get
			{
				return this.nameStyle;
			}

			set
			{
				this.nameStyle = value;
			}
		}

		private string title;

		public string Title
		{
			get
			{
				return this.title.IsEmptyOrZeroOrNull() ? null : this.title;
			}

			set
			{
				this.title = value;
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

		private string middleName;

		public string MiddleName
		{
			get
			{
				return this.middleName.IsEmptyOrZeroOrNull() ? null : this.middleName;
			}

			set
			{
				this.middleName = value;
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

		private string suffix;

		public string Suffix
		{
			get
			{
				return this.suffix.IsEmptyOrZeroOrNull() ? null : this.suffix;
			}

			set
			{
				this.suffix = value;
			}
		}

		private int emailPromotion;

		[Required]
		public int EmailPromotion
		{
			get
			{
				return this.emailPromotion;
			}

			set
			{
				this.emailPromotion = value;
			}
		}

		private string additionalContactInfo;

		public string AdditionalContactInfo
		{
			get
			{
				return this.additionalContactInfo.IsEmptyOrZeroOrNull() ? null : this.additionalContactInfo;
			}

			set
			{
				this.additionalContactInfo = value;
			}
		}

		private string demographics;

		public string Demographics
		{
			get
			{
				return this.demographics.IsEmptyOrZeroOrNull() ? null : this.demographics;
			}

			set
			{
				this.demographics = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>74cac465f4d8f0b08efe9f694ec50bc3</Hash>
</Codenesium>*/