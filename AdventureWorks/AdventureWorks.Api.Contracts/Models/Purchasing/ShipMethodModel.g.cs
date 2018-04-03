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
		public ShipMethodModel(string name,
		                       decimal shipBase,
		                       decimal shipRate,
		                       Guid rowguid,
		                       DateTime modifiedDate)
		{
			this.Name = name;
			this.ShipBase = shipBase;
			this.ShipRate = shipRate;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string _name;
		[Required]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
			}
		}

		private decimal _shipBase;
		[Required]
		public decimal ShipBase
		{
			get
			{
				return _shipBase;
			}
			set
			{
				this._shipBase = value;
			}
		}

		private decimal _shipRate;
		[Required]
		public decimal ShipRate
		{
			get
			{
				return _shipRate;
			}
			set
			{
				this._shipRate = value;
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
    <Hash>0ae858ee223c8e7ad9067a9fe791509b</Hash>
</Codenesium>*/