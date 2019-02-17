using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiStoreClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int businessEntityID,
			string demographic,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			int? salesPersonID)
		{
			this.BusinessEntityID = businessEntityID;
			this.Demographic = demographic;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.SalesPersonID = salesPersonID;

			this.SalesPersonIDEntity = nameof(ApiResponse.SalesPersons);
		}

		[JsonProperty]
		public ApiSalesPersonClientResponseModel SalesPersonIDNavigation { get; private set; }

		public void SetSalesPersonIDNavigation(ApiSalesPersonClientResponseModel value)
		{
			this.SalesPersonIDNavigation = value;
		}

		[JsonProperty]
		public int BusinessEntityID { get; private set; }

		[JsonProperty]
		public string Demographic { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public int? SalesPersonID { get; private set; }

		[JsonProperty]
		public string SalesPersonIDEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>6f0b7d531a3317b70ac5346f4551b61f</Hash>
</Codenesium>*/