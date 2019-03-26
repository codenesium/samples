using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class ApiEventTeacherServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiEventTeacherServerRequestModel()
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
    <Hash>f91070ecfd832d198e91225ddf3521fc</Hash>
</Codenesium>*/