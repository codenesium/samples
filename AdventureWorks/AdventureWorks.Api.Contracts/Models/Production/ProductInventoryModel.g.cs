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

		public ProductInventoryModel(
			int bin,
			short locationID,
			DateTime modifiedDate,
			short quantity,
			Guid rowguid,
			string shelf)
		{
			this.Bin = bin.ToInt();
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Quantity = quantity;
			this.Rowguid = rowguid.ToGuid();
			this.Shelf = shelf.ToString();
		}

		private int bin;

		[Required]
		public int Bin
		{
			get
			{
				return this.bin;
			}

			set
			{
				this.bin = value;
			}
		}

		private short locationID;

		[Required]
		public short LocationID
		{
			get
			{
				return this.locationID;
			}

			set
			{
				this.locationID = value;
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

		private short quantity;

		[Required]
		public short Quantity
		{
			get
			{
				return this.quantity;
			}

			set
			{
				this.quantity = value;
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

		private string shelf;

		[Required]
		public string Shelf
		{
			get
			{
				return this.shelf;
			}

			set
			{
				this.shelf = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>5c5c1bd62bb73709ecc21b4c8f10fb6d</Hash>
</Codenesium>*/