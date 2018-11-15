using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiPostHistoryTypeServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string type)
		{
			this.Id = id;
			this.Type = type;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>627f4fde5103b81ed2a3cbaf82c3c2b2</Hash>
</Codenesium>*/