using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiProductModelServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiProductModelServerRequestModel()
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

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>5949bb800fa3a1f3178dd7478f1e0303</Hash>
</Codenesium>*/