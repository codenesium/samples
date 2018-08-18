using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiStudentXFamilyResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int familyId,
			int studentId)
		{
			this.Id = id;
			this.FamilyId = familyId;
			this.StudentId = studentId;

			this.FamilyIdEntity = nameof(ApiResponse.Families);
			this.StudentIdEntity = nameof(ApiResponse.Students);
		}

		[Required]
		[JsonProperty]
		public int FamilyId { get; private set; }

		[JsonProperty]
		public string FamilyIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public int StudentId { get; private set; }

		[JsonProperty]
		public string StudentIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>99d56dea5efb787603592c1b6a062675</Hash>
</Codenesium>*/