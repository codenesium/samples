using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiStoreServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiStoreServerRequestModel()
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
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public int? SalesPersonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5444044226d750de41359ac4cc24d448</Hash>
</Codenesium>*/