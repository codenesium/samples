using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiLessonStatusResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			int studioId)
		{
			this.Id = id;
			this.Name = name;
			this.StudioId = studioId;

			this.IdEntity = nameof(ApiResponse.Studios);
			this.StudioIdEntity = nameof(ApiResponse.Studios);
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string IdEntity { get; set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int StudioId { get; private set; }

		[JsonProperty]
		public string StudioIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>9d16b140eb0089dc15d6b9e199bf2a79</Hash>
</Codenesium>*/