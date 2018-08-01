using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiSpaceResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string description,
			string name,
			int studioId)
		{
			this.Id = id;
			this.Description = description;
			this.Name = name;
			this.StudioId = studioId;

			this.StudioIdEntity = nameof(ApiResponse.Studios);
		}

		[Required]
		[JsonProperty]
		public string Description { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int StudioId { get; private set; }

		[JsonProperty]
		public string StudioIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>574fd6a14f5cabd6096e9c330d413188</Hash>
</Codenesium>*/