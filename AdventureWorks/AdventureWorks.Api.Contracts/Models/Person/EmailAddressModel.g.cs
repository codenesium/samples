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

		public EmailAddressModel(
			int emailAddressID,
			string emailAddress1,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.EmailAddressID = emailAddressID.ToInt();
			this.EmailAddress1 = emailAddress1;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
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
    <Hash>d300ad32002f414acbc05aee032d07f9</Hash>
</Codenesium>*/