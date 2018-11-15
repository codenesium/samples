using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiBusinessEntityServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiBusinessEntityServerRequestModel()
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

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>d2a830a43bdb42a2ed1ce02234135aba</Hash>
</Codenesium>*/