using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractBOTeacherSkill : AbstractBusinessObject
	{
		public AbstractBOTeacherSkill()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name,
		                                  int studioId)
		{
			this.Id = id;
			this.Name = name;
			this.StudioId = studioId;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>19764aa4f95fa6c4db02b6739d35d644</Hash>
</Codenesium>*/