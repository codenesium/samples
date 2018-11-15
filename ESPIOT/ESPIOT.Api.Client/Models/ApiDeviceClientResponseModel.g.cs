using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Client
{
	public partial class ApiDeviceClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			Guid publicId)
		{
			this.Id = id;
			this.Name = name;
			this.PublicId = publicId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public Guid PublicId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>74fd024021a89ffa30a04374ce727c95</Hash>
</Codenesium>*/