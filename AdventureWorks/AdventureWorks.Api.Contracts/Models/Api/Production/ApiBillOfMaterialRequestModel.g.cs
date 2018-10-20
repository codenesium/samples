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
		public short BOMLevel { get; private set; } = default(short);

		[Required]
		[JsonProperty]
		public int ComponentID { get; private set; } = default(int);

		[JsonProperty]
		public DateTime? EndDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public double PerAssemblyQty { get; private set; } = default(double);

		[JsonProperty]
		public int? ProductAssemblyID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public string UnitMeasureCode { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>5b539d027ff161d658b5ebfced31cbf8</Hash>
</Codenesium>*/