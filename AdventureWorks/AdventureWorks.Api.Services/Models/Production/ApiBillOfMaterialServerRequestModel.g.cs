using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiBillOfMaterialServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiBillOfMaterialServerRequestModel()
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
		public short BOMLevel { get; private set; } = default(short);

		[Required]
		[JsonProperty]
		public int ComponentID { get; private set; }

		[JsonProperty]
		public DateTime? EndDate { get; private set; } = null;

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public double PerAssemblyQty { get; private set; } = default(double);

		[JsonProperty]
		public int? ProductAssemblyID { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3aa8c3f3036923c5e7c6659db30c40cd</Hash>
</Codenesium>*/