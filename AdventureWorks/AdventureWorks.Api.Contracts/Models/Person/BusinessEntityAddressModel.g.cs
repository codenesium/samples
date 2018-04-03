using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class BusinessEntityAddressModel
	{
		public BusinessEntityAddressModel()
		{}
		public BusinessEntityAddressModel(int addressID,
		                                  int addressTypeID,
		                                  Guid rowguid,
		                                  DateTime modifiedDate)
		{
			this.AddressID = addressID.ToInt();
			this.AddressTypeID = addressTypeID.ToInt();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int _addressID;
		[Required]
		public int AddressID
		{
			get
			{
				return _addressID;
			}
			set
			{
				this._addressID = value;
			}
		}

		private int _addressTypeID;
		[Required]
		public int AddressTypeID
		{
			get
			{
				return _addressTypeID;
			}
			set
			{
				this._addressTypeID = value;
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
    <Hash>ee5143027a659d1181ee6fee25d4aac9</Hash>
</Codenesium>*/