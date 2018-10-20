using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiLocationRequestModel : AbstractApiRequestModel
	{
		public ApiLocationRequestModel()
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
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>565c915ff93fbb5ba4b05a053f2b02ab</Hash>
</Codenesium>*/