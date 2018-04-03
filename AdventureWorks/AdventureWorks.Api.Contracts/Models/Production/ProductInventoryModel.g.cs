using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductInventoryModel
	{
		public ProductInventoryModel()
		{}
		public ProductInventoryModel(short locationID,
		                             string shelf,
		                             int bin,
		                             short quantity,
		                             Guid rowguid,
		                             DateTime modifiedDate)
		{
			this.LocationID = locationID;
			this.Shelf = shelf;
			this.Bin = bin;
			this.Quantity = quantity;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private short _locationID;
		[Required]
		public short LocationID
		{
			get
			{
				return _locationID;
			}
			set
			{
				this._locationID = value;
			}
		}

		private string _shelf;
		[Required]
		public string Shelf
		{
			get
			{
				return _shelf;
			}
			set
			{
				this._shelf = value;
			}
		}

		private int _bin;
		[Required]
		public int Bin
		{
			get
			{
				return _bin;
			}
			set
			{
				this._bin = value;
			}
		}

		private short _quantity;
		[Required]
		public short Quantity
		{
			get
			{
				return _quantity;
			}
			set
			{
				this._quantity = value;
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
    <Hash>a0289b63269665ffcb4ee32ee4ccef39</Hash>
</Codenesium>*/