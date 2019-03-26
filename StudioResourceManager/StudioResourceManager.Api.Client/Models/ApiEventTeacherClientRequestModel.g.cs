using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiEventTeacherClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiEventTeacherClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int teacherId)
		{
			this.TeacherId = teacherId;
		}

		[JsonProperty]
		public int TeacherId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>df11da6bb61650c68948610afe7b8f90</Hash>
</Codenesium>*/