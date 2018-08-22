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
		                                  int studentId,
		                                  int studioId)
		{
			this.Id = id;
			this.FamilyId = familyId;
			this.StudentId = studentId;
			this.StudioId = studioId;
		}

		public int Id { get; private set; }

		public int FamilyId { get; private set; }

		public int StudentId { get; private set; }

		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>99e0d2472101d309ba70de9a32b0a698</Hash>
</Codenesium>*/