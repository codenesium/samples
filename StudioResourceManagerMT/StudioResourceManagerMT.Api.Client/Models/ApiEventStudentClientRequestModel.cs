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
			int eventId,
			int studentId)
		{
			this.EventId = eventId;
			this.StudentId = studentId;
		}

		[JsonProperty]
		public int EventId { get; private set; }

		[JsonProperty]
		public int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a52551d8820cd0971407ffdb1889f535</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/