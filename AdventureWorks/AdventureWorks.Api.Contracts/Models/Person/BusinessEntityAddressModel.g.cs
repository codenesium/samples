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

		public BusinessEntityAddressModel(
			int addressID,
			int addressTypeID,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.AddressID = addressID.ToInt();
			this.AddressTypeID = addressTypeID.ToInt();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int addressID;

		[Required]
		public int AddressID
		{
			get
			{
				return this.addressID;
			}

			set
			{
				this.addressID = value;
			}
		}

		private int addressTypeID;

		[Required]
		public int AddressTypeID
		{
			get
			{
				return this.addressTypeID;
			}

			set
			{
				this.addressTypeID = value;
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
    <Hash>ca5a30d1a54c1583e799ef9255c246e9</Hash>
</Codenesium>*/