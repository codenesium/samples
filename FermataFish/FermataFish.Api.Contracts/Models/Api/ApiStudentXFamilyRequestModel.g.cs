using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiStudentXFamilyRequestModel : AbstractApiRequestModel
	{
		public ApiStudentXFamilyRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int familyId,
			int studentId,
			int studioId)
		{
			this.FamilyId = familyId;
			this.StudentId = studentId;
			this.StudioId = studioId;
		}

		[Required]
		[JsonProperty]
		public int FamilyId { get; private set; }

		[Required]
		[JsonProperty]
		public int StudentId { get; private set; }

		[Required]
		[JsonProperty]
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>56949becf83e4c512812e77661592dd9</Hash>
</Codenesium>*/