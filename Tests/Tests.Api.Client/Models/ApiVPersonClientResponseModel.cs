using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiVPersonClientResponseModel : AbstractApiClientResponseModel
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
    <Hash>20354617c5974c72da855bf86ca54682</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/