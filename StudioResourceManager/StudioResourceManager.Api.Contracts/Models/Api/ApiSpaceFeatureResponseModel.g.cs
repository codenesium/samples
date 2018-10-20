using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiSpaceFeatureResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			bool isDeleted)
		{
			this.Id = id;
			this.Name = name;
			this.IsDeleted = isDeleted;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cf6f1fab82b3a28ee999485bd17bd40a</Hash>
</Codenesium>*/