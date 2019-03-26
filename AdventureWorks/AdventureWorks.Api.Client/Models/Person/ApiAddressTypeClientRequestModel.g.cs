using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiAddressTypeClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiAddressTypeClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string name,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>6c17b9fce7d16f843c887b610e49cf58</Hash>
</Codenesium>*/