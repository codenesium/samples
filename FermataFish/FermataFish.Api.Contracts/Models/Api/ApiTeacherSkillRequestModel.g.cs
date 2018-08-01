using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiTeacherSkillRequestModel : AbstractApiRequestModel
	{
		public ApiTeacherSkillRequestModel()
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
    <Hash>fedc5cb9a3019ba6df5c380915274cbe</Hash>
</Codenesium>*/