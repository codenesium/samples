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

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>64dbca471eb308a579cfc1ea881ae8a1</Hash>
</Codenesium>*/