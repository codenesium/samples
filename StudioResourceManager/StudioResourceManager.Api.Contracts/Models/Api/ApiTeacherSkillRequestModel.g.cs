using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiTeacherSkillRequestModel : AbstractApiRequestModel
	{
		public ApiTeacherSkillRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			bool isDeleted)
		{
			this.Name = name;
			this.IsDeleted = isDeleted;
		}

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>8b12a55bd4395e1b84e59cdd8fed5b53</Hash>
</Codenesium>*/