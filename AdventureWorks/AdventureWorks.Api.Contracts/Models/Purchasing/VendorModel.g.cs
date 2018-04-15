using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class VendorModel
	{
		public VendorModel()
		{}

		public VendorModel(
			string accountNumber,
			string name,
			int creditRating,
			bool preferredVendorStatus,
			bool activeFlag,
			string purchasingWebServiceURL,
			DateTime modifiedDate)
		{
			this.AccountNumber = accountNumber.ToString();
			this.Name = name.ToString();
			this.CreditRating = creditRating.ToInt();
			this.PreferredVendorStatus = preferredVendorStatus.ToBoolean();
			this.ActiveFlag = activeFlag.ToBoolean();
			this.PurchasingWebServiceURL = purchasingWebServiceURL.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string accountNumber;

		[Required]
		public string AccountNumber
		{
			get
			{
				return this.accountNumber;
			}

			set
			{
				this.accountNumber = value;
			}
		}

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		private int creditRating;

		[Required]
		public int CreditRating
		{
			get
			{
				return this.creditRating;
			}

			set
			{
				this.creditRating = value;
			}
		}

		private bool preferredVendorStatus;

		[Required]
		public bool PreferredVendorStatus
		{
			get
			{
				return this.preferredVendorStatus;
			}

			set
			{
				this.preferredVendorStatus = value;
			}
		}

		private bool activeFlag;

		[Required]
		public bool ActiveFlag
		{
			get
			{
				return this.activeFlag;
			}

			set
			{
				this.activeFlag = value;
			}
		}

		private string purchasingWebServiceURL;

		public string PurchasingWebServiceURL
		{
			get
			{
				return this.purchasingWebServiceURL.IsEmptyOrZeroOrNull() ? null : this.purchasingWebServiceURL;
			}

			set
			{
				this.purchasingWebServiceURL = value;
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
    <Hash>c19b6bb0d1371ca36bbc4157c7676376</Hash>
</Codenesium>*/