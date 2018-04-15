using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ShipMethodModel
	{
		public ShipMethodModel()
		{}

		public ShipMethodModel(
			string name,
			decimal shipBase,
			decimal shipRate,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.Name = name.ToString();
			this.ShipBase = shipBase.ToDecimal();
			this.ShipRate = shipRate.ToDecimal();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
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
    <Hash>f3e7d031f48f751781c1e6055828427d</Hash>
</Codenesium>*/