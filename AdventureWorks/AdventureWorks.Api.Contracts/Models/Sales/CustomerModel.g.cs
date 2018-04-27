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
			string accountNumber,
			DateTime modifiedDate,
			Nullable<int> personID,
			Guid rowguid,
			Nullable<int> storeID,
			Nullable<int> territoryID)
		{
			this.AccountNumber = accountNumber.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PersonID = personID.ToNullableInt();
			this.Rowguid = rowguid.ToGuid();
			this.StoreID = storeID.ToNullableInt();
			this.TerritoryID = territoryID.ToNullableInt();
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
	}
}

/*<Codenesium>
    <Hash>9ccbf79d9e75f50c6b531008be84e542</Hash>
</Codenesium>*/