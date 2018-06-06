using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
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
    <Hash>275a111cd133f33566faf4401016ab58</Hash>
</Codenesium>*/