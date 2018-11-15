using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiLocationClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiLocationClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			double availability,
			decimal costRate,
			DateTime modifiedDate,
			string name)
		{
			this.Availability = availability;
			this.CostRate = costRate;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[JsonProperty]
		public double Availability { get; private set; } = default(double);

		[JsonProperty]
		public decimal CostRate { get; private set; } = default(decimal);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>415a044cb0fb41713fbc30bb65cc715f</Hash>
</Codenesium>*/