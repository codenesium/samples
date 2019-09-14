using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiIncludedColumnTestServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			string name2)
		{
			this.Id = id;
			this.Name = name;
			this.Name2 = name2;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string Name2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d061629be6a96025a5763057e6d65d57</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/