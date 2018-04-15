using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class CustomerModel
	{
		public CustomerModel()
		{}

		public CustomerModel(
			Nullable<int> personID,
			Nullable<int> storeID,
			Nullable<int> territoryID,
			string accountNumber,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.PersonID = personID.ToNullableInt();
			this.StoreID = storeID.ToNullableInt();
			this.TerritoryID = territoryID.ToNullableInt();
			this.AccountNumber = accountNumber.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private Nullable<int> personID;

		public Nullable<int> PersonID
		{
			get
			{
				return this.personID.IsEmptyOrZeroOrNull() ? null : this.personID;
			}

			set
			{
				this.personID = value;
			}
		}

		private Nullable<int> storeID;

		public Nullable<int> StoreID
		{
			get
			{
				return this.storeID.IsEmptyOrZeroOrNull() ? null : this.storeID;
			}

			set
			{
				this.storeID = value;
			}
		}

		private Nullable<int> territoryID;

		public Nullable<int> TerritoryID
		{
			get
			{
				return this.territoryID.IsEmptyOrZeroOrNull() ? null : this.territoryID;
			}

			set
			{
				this.territoryID = value;
			}
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
    <Hash>426456a30294e37269ccfc36c685c6f4</Hash>
</Codenesium>*/