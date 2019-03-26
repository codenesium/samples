using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiBusinessEntityClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiBusinessEntityClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>169afaeb589a1500284fa7ecd951ccb4</Hash>
</Codenesium>*/