using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiCompositePrimaryKeyServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiCompositePrimaryKeyServerRequestModel()
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
		public int Id2 { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>85c287e6f35ff66c05c463005cf91ba1</Hash>
</Codenesium>*/