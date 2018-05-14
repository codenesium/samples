using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiEmailAddressModel
	{
		public ApiEmailAddressModel()
		{}

		public ApiEmailAddressModel(
			string emailAddress1,
			int emailAddressID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.EmailAddress1 = emailAddress1.ToString();
			this.EmailAddressID = emailAddressID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
		}

		private string emailAddress1;

		public string EmailAddress1
		{
			get
			{
				return this.emailAddress1.IsEmptyOrZeroOrNull() ? null : this.emailAddress1;
			}

			set
			{
				this.emailAddress1 = value;
			}
		}

		private int emailAddressID;

		[Required]
		public int EmailAddressID
		{
			get
			{
				return this.emailAddressID;
			}

			set
			{
				this.emailAddressID = value;
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
	}
}

/*<Codenesium>
    <Hash>acc1832d3233bf32c046cd4153ce7391</Hash>
</Codenesium>*/