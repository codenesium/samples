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
			int studentId)
		{
			this.FamilyId = familyId;
			this.StudentId = studentId;
		}

		[JsonProperty]
		public int FamilyId { get; private set; }

		[JsonProperty]
		public int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3cfd189c1aee9aebc3a1dc6147f37191</Hash>
</Codenesium>*/