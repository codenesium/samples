using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiLocationServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiLocationServerRequestModel()
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

		[Required]
		[JsonProperty]
		public double Availability { get; private set; } = default(double);

		[Required]
		[JsonProperty]
		public decimal CostRate { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>4bf5c14047e8c157058668742d99ef20</Hash>
</Codenesium>*/