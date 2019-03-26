using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiPostTypeClientResponseModel : AbstractApiClientResponseModel
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
    <Hash>8aa6a3cafb1dd733330d5169097c622f</Hash>
</Codenesium>*/