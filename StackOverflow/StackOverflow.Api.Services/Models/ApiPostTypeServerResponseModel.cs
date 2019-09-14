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
    <Hash>d36ebb2be155795d233a485668c56541</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/