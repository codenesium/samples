using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiUnitMeasureResponseModel : AbstractApiResponseModel
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
    <Hash>95eca1fd23c597131c7760032a02d2a2</Hash>
</Codenesium>*/