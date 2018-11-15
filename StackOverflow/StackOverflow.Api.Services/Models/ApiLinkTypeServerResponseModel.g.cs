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
    <Hash>8f5ec2d8573b56df4e3cb7c7e1de1ab5</Hash>
</Codenesium>*/