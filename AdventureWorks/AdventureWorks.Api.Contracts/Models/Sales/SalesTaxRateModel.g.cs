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

		public SalesTaxRateModel(
			int stateProvinceID,
			int taxType,
			decimal taxRate,
			string name,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.StateProvinceID = stateProvinceID.ToInt();
			this.TaxType = taxType.ToInt();
			this.TaxRate = taxRate.ToDecimal();
			this.Name = name.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int stateProvinceID;

		[Required]
		public int StateProvinceID
		{
			get
			{
				return this.stateProvinceID;
			}

			set
			{
				this.stateProvinceID = value;
			}
		}

		private int taxType;

		[Required]
		public int TaxType
		{
			get
			{
				return this.taxType;
			}

			set
			{
				this.taxType = value;
			}
		}

		private decimal taxRate;

		[Required]
		public decimal TaxRate
		{
			get
			{
				return this.taxRate;
			}

			set
			{
				this.taxRate = value;
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
    <Hash>af369612bd92d9afaf1805c7f5e6efe3</Hash>
</Codenesium>*/