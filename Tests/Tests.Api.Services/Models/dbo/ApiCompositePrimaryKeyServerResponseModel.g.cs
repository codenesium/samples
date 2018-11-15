using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiCompositePrimaryKeyServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int id2)
		{
			this.Id = id;
			this.Id2 = id2;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int Id2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a5aafaf1e80c073a20c32cb196952f63</Hash>
</Codenesium>*/