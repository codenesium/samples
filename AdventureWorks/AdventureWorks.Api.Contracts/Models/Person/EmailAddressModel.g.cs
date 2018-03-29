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
		                         string emailAddress1,
		                         Guid rowguid,
		                         DateTime modifiedDate)
		{
			this.EmailAddressID = emailAddressID.ToInt();
			this.EmailAddress1 = emailAddress1;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public EmailAddressModel(POCOEmailAddress poco)
		{
			this.EmailAddressID = poco.EmailAddressID.ToInt();
			this.EmailAddress1 = poco.EmailAddress1;
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();
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

		private string _emailAddress1;
		public string EmailAddress1
		{
			get
			{
				return _emailAddress1.IsEmptyOrZeroOrNull() ? null : _emailAddress1;
			}
			set
			{
				this._emailAddress1 = value;
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
    <Hash>8b646e60942703ba7ced5dfff05de58c</Hash>
</Codenesium>*/