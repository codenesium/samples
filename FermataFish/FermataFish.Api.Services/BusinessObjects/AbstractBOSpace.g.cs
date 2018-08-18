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
			this.Description = description;
			this.Id = id;
			this.Name = name;
			this.StudioId = studioId;
		}

		public string Description { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }

		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b059d11e7feffd4c15a905e793b1a8ce</Hash>
</Codenesium>*/