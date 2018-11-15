using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractBOTeacherSkill : AbstractBusinessObject
	{
		public AbstractBOTeacherSkill()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name)
		{
			this.Id = id;
			this.Name = name;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>47f3aa39d95940832668d827eef05f42</Hash>
</Codenesium>*/