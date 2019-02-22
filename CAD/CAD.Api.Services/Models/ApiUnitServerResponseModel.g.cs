using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiUnitServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string callSign)
		{
			this.Id = id;
			this.CallSign = callSign;
		}

		[Required]
		[JsonProperty]
		public string CallSign { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4c959deea36ec5c421260ff48ba41cb7</Hash>
</Codenesium>*/