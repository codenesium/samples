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
			int teacherId,
			bool isDeleted)
		{
			this.TeacherId = teacherId;
			this.IsDeleted = isDeleted;
		}

		[Required]
		[JsonProperty]
		public int TeacherId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>11e63f37421e2c0c29151c0e52305a66</Hash>
</Codenesium>*/