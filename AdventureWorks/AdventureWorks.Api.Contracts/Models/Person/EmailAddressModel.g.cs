using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class EmailAddressModel
	{
		public EmailAddressModel()
		{}
		public EmailAddressModel(int emailAddressID,
		                         string emailAddress,
		                         Guid rowguid,
		                         DateTime modifiedDate)
		{
			this.EmailAddressID = emailAddressID.ToInt();
			this.EmailAddress = emailAddress;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int _emailAddressID;
		[Required]
		public int EmailAddressID
		{
			get
			{
				return _emailAddressID;
			}
			set
			{
				this._emailAddressID = value;
			}
		}

		private string _emailAddress;
		public string EmailAddress
		{
			get
			{
				return _emailAddress.IsEmptyOrZeroOrNull() ? null : _emailAddress;
			}
			set
			{
				this._emailAddress = value;
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
    <Hash>2865040d9647c939848447c05708fe91</Hash>
</Codenesium>*/