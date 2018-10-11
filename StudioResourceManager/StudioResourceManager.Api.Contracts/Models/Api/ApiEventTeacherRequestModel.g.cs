using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiEventTeacherRequestModel : AbstractApiRequestModel
	{
		public ApiEventTeacherRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int teacherId)
		{
			this.TeacherId = teacherId;
		}

		[Required]
		[JsonProperty]
		public int TeacherId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1ff9a0b7ac07f4de436f11c90a92abaa</Hash>
</Codenesium>*/