using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiShipMethodModel: AbstractModel
	{
		public ApiShipMethodModel() : base()
		{}

		public ApiShipMethodModel(
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			decimal shipBase,
			decimal shipRate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
			this.ShipBase = shipBase.ToDecimal();
			this.ShipRate = shipRate.ToDecimal();
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

		private decimal shipBase;

		[Required]
		public decimal ShipBase
		{
			get
			{
				return this.shipBase;
			}

			set
			{
				this.shipBase = value;
			}
		}

		private decimal shipRate;

		[Required]
		public decimal ShipRate
		{
			get
			{
				return this.shipRate;
			}

			set
			{
				this.shipRate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>cef47f8aec104a8cd700b22ed089eaf3</Hash>
</Codenesium>*/