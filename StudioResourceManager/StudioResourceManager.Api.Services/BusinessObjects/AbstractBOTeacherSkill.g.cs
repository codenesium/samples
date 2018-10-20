using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOTeacherSkill : AbstractBusinessObject
	{
		public AbstractBOTeacherSkill()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name,
		                                  bool isDeleted)
		{
			this.Id = id;
			this.Name = name;
			this.IsDeleted = isDeleted;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1088b787107093028daff80412835f1a</Hash>
</Codenesium>*/