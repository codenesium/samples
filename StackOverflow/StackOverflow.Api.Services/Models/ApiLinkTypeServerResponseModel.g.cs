using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiLinkTypeServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>d6b9a2301ddf4f85eb447b3c14654b5b</Hash>
</Codenesium>*/