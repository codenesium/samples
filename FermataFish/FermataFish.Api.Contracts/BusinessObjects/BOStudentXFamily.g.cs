using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class BOStudentXFamily: AbstractBusinessObject
	{
		public BOStudentXFamily() : base()
		{}

		public void SetProperties(int id,
		                          int familyId,
		                          int studentId)
		{
			this.FamilyId = familyId.ToInt();
			this.Id = id.ToInt();
			this.StudentId = studentId.ToInt();
		}

		public int FamilyId { get; private set; }
		public int Id { get; private set; }
		public int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ebe863f637f8ed51cf63eac39019918e</Hash>
</Codenesium>*/