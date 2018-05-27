using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiStudentXFamilyResponseModel: AbstractApiResponseModel
	{
		public ApiStudentXFamilyResponseModel() : base()
		{}

		public void SetProperties(
			int familyId,
			int id,
			int studentId)
		{
			this.Id = id.ToInt();

			this.FamilyId = new ReferenceEntity<int>(familyId,
			                                         nameof(ApiResponse.Families));
			this.StudentId = new ReferenceEntity<int>(studentId,
			                                          nameof(ApiResponse.Students));
		}

		public ReferenceEntity<int> FamilyId { get; set; }
		public int Id { get; set; }
		public ReferenceEntity<int> StudentId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeFamilyIdValue { get; set; } = true;

		public bool ShouldSerializeFamilyId()
		{
			return this.ShouldSerializeFamilyIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStudentIdValue { get; set; } = true;

		public bool ShouldSerializeStudentId()
		{
			return this.ShouldSerializeStudentIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeFamilyIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeStudentIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>02007366bd02ca7f2931792051cb2ee7</Hash>
</Codenesium>*/