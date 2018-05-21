using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPersonPhoneModel: AbstractModel
	{
		public ApiPersonPhoneModel() : base()
		{}

		public ApiPersonPhoneModel(
			DateTime modifiedDate,
			string phoneNumber,
			int phoneNumberTypeID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PhoneNumber = phoneNumber;
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
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

		private string phoneNumber;

		[Required]
		public string PhoneNumber
		{
			get
			{
				return this.phoneNumber;
			}

			set
			{
				this.phoneNumber = value;
			}
		}

		private int phoneNumberTypeID;

		[Required]
		public int PhoneNumberTypeID
		{
			get
			{
				return this.phoneNumberTypeID;
			}

			set
			{
				this.phoneNumberTypeID = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>fcf38065f79f80061ea433e2e71ed771</Hash>
</Codenesium>*/