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
			int studentId,
			int studioId)
		{
			this.Id = id;
			this.FamilyId = familyId;
			this.StudentId = studentId;
			this.StudioId = studioId;

			this.FamilyIdEntity = nameof(ApiResponse.Families);
			this.StudentIdEntity = nameof(ApiResponse.Students);
			this.StudioIdEntity = nameof(ApiResponse.Studios);
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int FamilyId { get; private set; }

		[JsonProperty]
		public string FamilyIdEntity { get; set; }

		[JsonProperty]
		public int StudentId { get; private set; }

		[JsonProperty]
		public string StudentIdEntity { get; set; }

		[JsonProperty]
		public int StudioId { get; private set; }

		[JsonProperty]
		public string StudioIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>4ed33c3200c82ecaf00f0e309db327b1</Hash>
</Codenesium>*/