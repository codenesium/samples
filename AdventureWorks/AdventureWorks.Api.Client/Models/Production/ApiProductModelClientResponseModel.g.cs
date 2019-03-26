using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductModelClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int productModelID,
			string catalogDescription,
			string instruction,
			DateTime modifiedDate,
			string name,
			Guid rowguid)
		{
			this.ProductModelID = productModelID;
			this.CatalogDescription = catalogDescription;
			this.Instruction = instruction;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
		}

		[JsonProperty]
		public string CatalogDescription { get; private set; }

		[JsonProperty]
		public string Instruction { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int ProductModelID { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>708c266c046b57b58b32c9df85cd1e60</Hash>
</Codenesium>*/