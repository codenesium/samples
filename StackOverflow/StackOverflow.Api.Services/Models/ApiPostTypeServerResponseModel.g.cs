using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiPostTypeServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>38004a6f838e02e8bee17be8fc951c60</Hash>
</Codenesium>*/