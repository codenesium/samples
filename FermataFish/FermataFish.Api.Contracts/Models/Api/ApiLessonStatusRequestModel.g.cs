using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiLessonStatusRequestModel : AbstractApiRequestModel
	{
		public ApiLessonStatusRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			int studioId)
		{
			this.Name = name;
			this.StudioId = studioId;
		}

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5f4b9308d9bcf6faeeb3b64f5acc72aa</Hash>
</Codenesium>*/