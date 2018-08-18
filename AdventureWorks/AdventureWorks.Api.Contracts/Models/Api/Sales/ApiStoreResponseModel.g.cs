using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiStoreResponseModel : AbstractApiResponseModel
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
		public string SalesPersonIDEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>7d1b5b3f93dcbe95c36d1754d119ec3b</Hash>
</Codenesium>*/