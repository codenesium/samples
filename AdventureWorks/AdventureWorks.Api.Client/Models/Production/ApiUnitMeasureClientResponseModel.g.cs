using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiUnitMeasureClientResponseModel : AbstractApiClientResponseModel
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
    <Hash>f3a108fc24484491ab17e1f1780a6229</Hash>
</Codenesium>*/