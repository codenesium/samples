using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractBOStudentXFamily : AbstractBusinessObject
	{
		public AbstractBOStudentXFamily()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int familyId,
		                                  int studentId)
		{
			this.FamilyId = familyId;
			this.Id = id;
			this.StudentId = studentId;
		}

		public int FamilyId { get; private set; }

		public int Id { get; private set; }

		public int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fced777385ebdda7588eb7f805cece87</Hash>
</Codenesium>*/