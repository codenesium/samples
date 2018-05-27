using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOStudentXFamily: AbstractDTO
	{
		public DTOStudentXFamily() : base()
		{}

		public void SetProperties(int id,
		                          int familyId,
		                          int studentId)
		{
			this.FamilyId = familyId.ToInt();
			this.Id = id.ToInt();
			this.StudentId = studentId.ToInt();
		}

		public int FamilyId { get; set; }
		public int Id { get; set; }
		public int StudentId { get; set; }
	}
}

/*<Codenesium>
    <Hash>382619ed01b3e7e52c02c9ac3a296b6e</Hash>
</Codenesium>*/