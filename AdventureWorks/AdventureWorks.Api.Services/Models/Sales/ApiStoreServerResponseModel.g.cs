using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiStoreServerResponseModel : AbstractApiServerResponseModel
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
		}

		[JsonProperty]
		public int BusinessEntityID { get; private set; }

		[Required]
		[JsonProperty]
		public string Demographic { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[Required]
		[JsonProperty]
		public int? SalesPersonID { get; private set; }

		[JsonProperty]
		public string SalesPersonIDEntity { get; private set; } = RouteConstants.SalesPersons;

		[JsonProperty]
		public ApiSalesPersonServerResponseModel SalesPersonIDNavigation { get; private set; }

		public void SetSalesPersonIDNavigation(ApiSalesPersonServerResponseModel value)
		{
			this.SalesPersonIDNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>48581fb815e43f57d31ce8e46d12778e</Hash>
</Codenesium>*/