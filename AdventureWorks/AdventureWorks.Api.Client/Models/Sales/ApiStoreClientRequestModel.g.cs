using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiStoreClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiStoreClientRequestModel()
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

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public int? SalesPersonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>33459db689ae1023aba7fe2b56ec09b3</Hash>
</Codenesium>*/