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

		public PersonModel(string personType,
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

		public PersonModel(POCOPerson poco)
		{
			this.PersonType = poco.PersonType;
			this.NameStyle = poco.NameStyle;
			this.Title = poco.Title;
			this.FirstName = poco.FirstName;
			this.MiddleName = poco.MiddleName;
			this.LastName = poco.LastName;
			this.Suffix = poco.Suffix;
			this.EmailPromotion = poco.EmailPromotion.ToInt();
			this.AdditionalContactInfo = poco.AdditionalContactInfo;
			this.Demographics = poco.Demographics;
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();
		}

		private string _personType;
		[Required]
		public string PersonType
		{
			get
			{
				return _personType;
			}
			set
			{
				this._personType = value;
			}
		}

		private bool _nameStyle;
		[Required]
		public bool NameStyle
		{
			get
			{
				return _nameStyle;
			}
			set
			{
				this._nameStyle = value;
			}
		}

		private string _title;
		public string Title
		{
			get
			{
				return _title.IsEmptyOrZeroOrNull() ? null : _title;
			}
			set
			{
				this._title = value;
			}
		}

		private string _firstName;
		[Required]
		public string FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
				this._firstName = value;
			}
		}

		private string _middleName;
		public string MiddleName
		{
			get
			{
				return _middleName.IsEmptyOrZeroOrNull() ? null : _middleName;
			}
			set
			{
				this._middleName = value;
			}
		}

		private string _lastName;
		[Required]
		public string LastName
		{
			get
			{
				return _lastName;
			}
			set
			{
				this._lastName = value;
			}
		}

		private string _suffix;
		public string Suffix
		{
			get
			{
				return _suffix.IsEmptyOrZeroOrNull() ? null : _suffix;
			}
			set
			{
				this._suffix = value;
			}
		}

		private int _emailPromotion;
		[Required]
		public int EmailPromotion
		{
			get
			{
				return _emailPromotion;
			}
			set
			{
				this._emailPromotion = value;
			}
		}

		private string _additionalContactInfo;
		public string AdditionalContactInfo
		{
			get
			{
				return _additionalContactInfo.IsEmptyOrZeroOrNull() ? null : _additionalContactInfo;
			}
			set
			{
				this._additionalContactInfo = value;
			}
		}

		private string _demographics;
		public string Demographics
		{
			get
			{
				return _demographics.IsEmptyOrZeroOrNull() ? null : _demographics;
			}
			set
			{
				this._demographics = value;
			}
		}

		private Guid _rowguid;
		[Required]
		public Guid Rowguid
		{
			get
			{
				return _rowguid;
			}
			set
			{
				this._rowguid = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>529622cf0c4bd48acd6c74395c2c961f</Hash>
</Codenesium>*/