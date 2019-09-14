using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class ApiEventStudentServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiEventStudentServerRequestModel()
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

		[Required]
		[JsonProperty]
		public int EventId { get; private set; }

		[Required]
		[JsonProperty]
		public int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9ea0bb311986592684a03c6eda8d5aed</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/