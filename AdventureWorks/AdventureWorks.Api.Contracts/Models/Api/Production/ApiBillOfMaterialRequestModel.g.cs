using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiBillOfMaterialRequestModel : AbstractApiRequestModel
	{
		public ApiBillOfMaterialRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			short bOMLevel,
			int componentID,
			DateTime? endDate,
			DateTime modifiedDate,
			double perAssemblyQty,
			int? productAssemblyID,
			DateTime startDate,
			string unitMeasureCode)
		{
			this.BOMLevel = bOMLevel;
			this.ComponentID = componentID;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.PerAssemblyQty = perAssemblyQty;
			this.ProductAssemblyID = productAssemblyID;
			this.StartDate = startDate;
			this.UnitMeasureCode = unitMeasureCode;
		}

		[Required]
		[JsonProperty]
		public short BOMLevel { get; private set; }

		[Required]
		[JsonProperty]
		public int ComponentID { get; private set; }

		[JsonProperty]
		public DateTime? EndDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public double PerAssemblyQty { get; private set; }

		[JsonProperty]
		public int? ProductAssemblyID { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; }

		[Required]
		[JsonProperty]
		public string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cce156378f242310e01f1f14c16c8338</Hash>
</Codenesium>*/