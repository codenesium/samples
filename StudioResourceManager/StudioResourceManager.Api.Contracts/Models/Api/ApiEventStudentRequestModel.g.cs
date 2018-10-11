using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiEventStudentRequestModel : AbstractApiRequestModel
	{
		public ApiEventStudentRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int studentId)
		{
			this.StudentId = studentId;
		}

		[Required]
		[JsonProperty]
		public int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8276688ebba1a18820150d6811cb9169</Hash>
</Codenesium>*/