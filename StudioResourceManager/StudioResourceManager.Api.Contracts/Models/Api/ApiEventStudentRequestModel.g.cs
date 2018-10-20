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
			int studentId,
			bool isDeleted)
		{
			this.StudentId = studentId;
			this.IsDeleted = isDeleted;
		}

		[Required]
		[JsonProperty]
		public int StudentId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>8f85af78fcad282b57eb15c8ba1963b3</Hash>
</Codenesium>*/