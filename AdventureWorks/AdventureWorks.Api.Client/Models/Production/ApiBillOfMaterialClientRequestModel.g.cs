using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiBillOfMaterialClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiBillOfMaterialClientRequestModel()
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

		[JsonProperty]
		public short BOMLevel { get; private set; } = default(short);

		[JsonProperty]
		public int ComponentID { get; private set; } = default(int);

		[JsonProperty]
		public DateTime? EndDate { get; private set; } = null;

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public double PerAssemblyQty { get; private set; } = default(double);

		[JsonProperty]
		public int? ProductAssemblyID { get; private set; } = default(int);

		[JsonProperty]
		public DateTime StartDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string UnitMeasureCode { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>510b894d3f5e9b49e06c23675e79ee20</Hash>
</Codenesium>*/