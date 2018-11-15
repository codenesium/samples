using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiProductDescriptionServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiProductDescriptionServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string description,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.Description = description;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
		}

		[Required]
		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>61020de92221bb693a82da9ccafe6416</Hash>
</Codenesium>*/