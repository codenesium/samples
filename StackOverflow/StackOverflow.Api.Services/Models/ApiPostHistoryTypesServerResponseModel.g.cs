using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiPostHistoryTypesServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string rwType)
		{
			this.Id = id;
			this.RwType = rwType;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string RwType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c871e5b64d1fa11f7f00535287773f73</Hash>
</Codenesium>*/