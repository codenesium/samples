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

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0a0f071fec08191fb6560ea60785005c</Hash>
</Codenesium>*/