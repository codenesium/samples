using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiStoreRequestModel : AbstractApiRequestModel
	{
		public ApiStoreRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string demographic,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			int? salesPersonID)
		{
			this.Demographic = demographic;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.SalesPersonID = salesPersonID;
		}

		[JsonProperty]
		public string Demographic { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public int? SalesPersonID { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>4105ae84757df6903fb7eaa3e8662083</Hash>
</Codenesium>*/