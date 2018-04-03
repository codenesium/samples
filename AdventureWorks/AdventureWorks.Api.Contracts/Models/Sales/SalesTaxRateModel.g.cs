using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class SalesTaxRateModel
	{
		public SalesTaxRateModel()
		{}
		public SalesTaxRateModel(int stateProvinceID,
		                         int taxType,
		                         decimal taxRate,
		                         string name,
		                         Guid rowguid,
		                         DateTime modifiedDate)
		{
			this.StateProvinceID = stateProvinceID.ToInt();
			this.TaxType = taxType;
			this.TaxRate = taxRate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int _stateProvinceID;
		[Required]
		public int StateProvinceID
		{
			get
			{
				return _stateProvinceID;
			}
			set
			{
				this._stateProvinceID = value;
			}
		}

		private int _taxType;
		[Required]
		public int TaxType
		{
			get
			{
				return _taxType;
			}
			set
			{
				this._taxType = value;
			}
		}

		private decimal _taxRate;
		[Required]
		public decimal TaxRate
		{
			get
			{
				return _taxRate;
			}
			set
			{
				this._taxRate = value;
			}
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
    <Hash>e371ad97c665ca20f33649ffa1abac97</Hash>
</Codenesium>*/