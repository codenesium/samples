using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiSpaceRequestModel : AbstractApiRequestModel
	{
		public ApiSpaceRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string description,
			string name,
			int studioId)
		{
			this.Description = description;
			this.Name = name;
			this.StudioId = studioId;
		}

		[Required]
		[JsonProperty]
		public string Description { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>14b14fafcd7ed2a31d175217c6ae7056</Hash>
</Codenesium>*/