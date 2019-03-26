using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductModelClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiProductModelClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string catalogDescription,
			string instruction,
			DateTime modifiedDate,
			string name,
			Guid rowguid)
		{
			this.CatalogDescription = catalogDescription;
			this.Instruction = instruction;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
		}

		[JsonProperty]
		public string CatalogDescription { get; private set; } = default(string);

		[JsonProperty]
		public string Instruction { get; private set; } = default(string);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>9c4344d7c2f933951919dd874125c1a0</Hash>
</Codenesium>*/