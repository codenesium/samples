using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>a1aa363ea12af6e1bd72a4b66724837a</Hash>
</Codenesium>*/