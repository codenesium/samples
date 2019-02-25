using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiBillOfMaterialServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int billOfMaterialsID,
			short bOMLevel,
			int componentID,
			DateTime? endDate,
			DateTime modifiedDate,
			double perAssemblyQty,
			int? productAssemblyID,
			DateTime startDate,
			string unitMeasureCode)
		{
			this.BillOfMaterialsID = billOfMaterialsID;
			this.BOMLevel = bOMLevel;
			this.ComponentID = componentID;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.PerAssemblyQty = perAssemblyQty;
			this.ProductAssemblyID = productAssemblyID;
			this.StartDate = startDate;
			this.UnitMeasureCode = unitMeasureCode;
		}

		[JsonProperty]
		public int BillOfMaterialsID { get; private set; }

		[JsonProperty]
		public short BOMLevel { get; private set; }

		[JsonProperty]
		public int ComponentID { get; private set; }

		[JsonProperty]
		public string ComponentIDEntity { get; private set; } = RouteConstants.Products;

		[JsonProperty]
		public ApiProductServerResponseModel ComponentIDNavigation { get; private set; }

		public void SetComponentIDNavigation(ApiProductServerResponseModel value)
		{
			this.ComponentIDNavigation = value;
		}

		[Required]
		[JsonProperty]
		public DateTime? EndDate { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public double PerAssemblyQty { get; private set; }

		[Required]
		[JsonProperty]
		public int? ProductAssemblyID { get; private set; }

		[JsonProperty]
		public string ProductAssemblyIDEntity { get; private set; } = RouteConstants.Products;

		[JsonProperty]
		public ApiProductServerResponseModel ProductAssemblyIDNavigation { get; private set; }

		public void SetProductAssemblyIDNavigation(ApiProductServerResponseModel value)
		{
			this.ProductAssemblyIDNavigation = value;
		}

		[JsonProperty]
		public DateTime StartDate { get; private set; }

		[JsonProperty]
		public string UnitMeasureCode { get; private set; }

		[JsonProperty]
		public string UnitMeasureCodeEntity { get; private set; } = RouteConstants.UnitMeasures;

		[JsonProperty]
		public ApiUnitMeasureServerResponseModel UnitMeasureCodeNavigation { get; private set; }

		public void SetUnitMeasureCodeNavigation(ApiUnitMeasureServerResponseModel value)
		{
			this.UnitMeasureCodeNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>7d36ef4e3b2d5b57f43ab5ef9fa89e5d</Hash>
</Codenesium>*/