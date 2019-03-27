using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiEventStudentServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiEventStudentServerRequestModel()
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
    <Hash>0d0d3201b0293e2e09bd0a7f6c680bbf</Hash>
</Codenesium>*/