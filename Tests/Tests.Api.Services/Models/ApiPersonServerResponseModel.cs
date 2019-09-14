using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiPersonServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int personId,
			string personName)
		{
			this.PersonId = personId;
			this.PersonName = personName;
		}

		[JsonProperty]
		public int PersonId { get; private set; }

		[JsonProperty]
		public string PersonName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4b024b034ec7ddec12d6e87466795ae0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/