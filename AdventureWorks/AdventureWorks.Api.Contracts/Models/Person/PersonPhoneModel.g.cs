using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class PersonPhoneModel
	{
		public PersonPhoneModel()
		{}

		public PersonPhoneModel(string phoneNumber,
		                        int phoneNumberTypeID,
		                        DateTime modifiedDate)
		{
			this.PhoneNumber = phoneNumber;
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public PersonPhoneModel(POCOPersonPhone poco)
		{
			this.PhoneNumber = poco.PhoneNumber;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.PhoneNumberTypeID = poco.PhoneNumberTypeID.Value.ToInt();
		}

		private string _phoneNumber;
		[Required]
		public string PhoneNumber
		{
			get
			{
				return _phoneNumber;
			}
			set
			{
				this._phoneNumber = value;
			}
		}

		private int _phoneNumberTypeID;
		[Required]
		public int PhoneNumberTypeID
		{
			get
			{
				return _phoneNumberTypeID;
			}
			set
			{
				this._phoneNumberTypeID = value;
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
    <Hash>62130e6842b546cc811ca12e5405ac9c</Hash>
</Codenesium>*/