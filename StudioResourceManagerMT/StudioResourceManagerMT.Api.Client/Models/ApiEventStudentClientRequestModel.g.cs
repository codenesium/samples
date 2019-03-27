using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiEventStudentClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiEventStudentClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int studentId)
		{
			this.StudentId = studentId;
		}

		[JsonProperty]
		public int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>065edb35890905dbbe56eb0cb643b8ee</Hash>
</Codenesium>*/