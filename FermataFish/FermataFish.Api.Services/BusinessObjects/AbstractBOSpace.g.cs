using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractBOSpace : AbstractBusinessObject
	{
		public AbstractBOSpace()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string description,
		                                  string name,
		                                  int studioId)
		{
			this.Id = id;
			this.Description = description;
			this.Name = name;
			this.StudioId = studioId;
		}

		public int Id { get; private set; }

		public string Description { get; private set; }

		public string Name { get; private set; }

		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>532463d273f1ad59d8b6c53403e0f10e</Hash>
</Codenesium>*/