using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiSpaceResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string description,
			string name,
			bool isDeleted)
		{
			this.Id = id;
			this.Description = description;
			this.Name = name;
			this.IsDeleted = isDeleted;
		}

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>091b8aca6c04d2b80ff4a13033d3bdf6</Hash>
</Codenesium>*/