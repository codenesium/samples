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
		public CustomerModel(Nullable<int> personID,
		                     Nullable<int> storeID,
		                     Nullable<int> territoryID,
		                     string accountNumber,
		                     Guid rowguid,
		                     DateTime modifiedDate)
		{
			this.PersonID = personID.ToNullableInt();
			this.StoreID = storeID.ToNullableInt();
			this.TerritoryID = territoryID.ToNullableInt();
			this.AccountNumber = accountNumber;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private Nullable<int> _personID;
		public Nullable<int> PersonID
		{
			get
			{
				return _personID.IsEmptyOrZeroOrNull() ? null : _personID;
			}
			set
			{
				this._personID = value;
			}
		}

		private Nullable<int> _storeID;
		public Nullable<int> StoreID
		{
			get
			{
				return _storeID.IsEmptyOrZeroOrNull() ? null : _storeID;
			}
			set
			{
				this._storeID = value;
			}
		}

		private Nullable<int> _territoryID;
		public Nullable<int> TerritoryID
		{
			get
			{
				return _territoryID.IsEmptyOrZeroOrNull() ? null : _territoryID;
			}
			set
			{
				this._territoryID = value;
			}
		}

		private string _accountNumber;
		[Required]
		public string AccountNumber
		{
			get
			{
				return _accountNumber;
			}
			set
			{
				this._accountNumber = value;
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
    <Hash>7afcb028bfd1a54fe5667b2775fbe8a6</Hash>
</Codenesium>*/