using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiUnitMeasureServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			string unitMeasureCode,
			DateTime modifiedDate,
			string name)
		{
			this.UnitMeasureCode = unitMeasureCode;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7eb15beb21f9ad26f88801c50d4720db</Hash>
</Codenesium>*/