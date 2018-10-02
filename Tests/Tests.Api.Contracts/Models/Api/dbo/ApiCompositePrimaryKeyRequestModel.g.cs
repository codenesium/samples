using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiCompositePrimaryKeyRequestModel : AbstractApiRequestModel
	{
		public ApiCompositePrimaryKeyRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int id2)
		{
			this.Id2 = id2;
		}

		[Required]
		[JsonProperty]
		public int Id2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a87c86da2842194e4c18f4a516ab7757</Hash>
</Codenesium>*/