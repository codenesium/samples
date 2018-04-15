using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class BillOfMaterialsModel
	{
		public BillOfMaterialsModel()
		{}

		public BillOfMaterialsModel(
			Nullable<int> productAssemblyID,
			int componentID,
			DateTime startDate,
			Nullable<DateTime> endDate,
			string unitMeasureCode,
			short bOMLevel,
			decimal perAssemblyQty,
			DateTime modifiedDate)
		{
			this.ProductAssemblyID = productAssemblyID.ToNullableInt();
			this.ComponentID = componentID.ToInt();
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.UnitMeasureCode = unitMeasureCode.ToString();
			this.BOMLevel = bOMLevel;
			this.PerAssemblyQty = perAssemblyQty.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private Nullable<int> productAssemblyID;

		public Nullable<int> ProductAssemblyID
		{
			get
			{
				return this.productAssemblyID.IsEmptyOrZeroOrNull() ? null : this.productAssemblyID;
			}

			set
			{
				this.productAssemblyID = value;
			}
		}

		private int componentID;

		[Required]
		public int ComponentID
		{
			get
			{
				return this.componentID;
			}

			set
			{
				this.componentID = value;
			}
		}

		private DateTime startDate;

		[Required]
		public DateTime StartDate
		{
			get
			{
				return this.startDate;
			}

			set
			{
				this.startDate = value;
			}
		}

		private Nullable<DateTime> endDate;

		public Nullable<DateTime> EndDate
		{
			get
			{
				return this.endDate.IsEmptyOrZeroOrNull() ? null : this.endDate;
			}

			set
			{
				this.endDate = value;
			}
		}

		private string unitMeasureCode;

		[Required]
		public string UnitMeasureCode
		{
			get
			{
				return this.unitMeasureCode;
			}

			set
			{
				this.unitMeasureCode = value;
			}
		}

		private short bOMLevel;

		[Required]
		public short BOMLevel
		{
			get
			{
				return this.bOMLevel;
			}

			set
			{
				this.bOMLevel = value;
			}
		}

		private decimal perAssemblyQty;

		[Required]
		public decimal PerAssemblyQty
		{
			get
			{
				return this.perAssemblyQty;
			}

			set
			{
				this.perAssemblyQty = value;
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
    <Hash>03af6eaf4ab55dd92f05cabaeccb8cf8</Hash>
</Codenesium>*/