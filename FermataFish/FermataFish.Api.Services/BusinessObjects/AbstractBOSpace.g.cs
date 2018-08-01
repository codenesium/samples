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
    <Hash>7c4150cc9bd4449608075048ae0c8f0a</Hash>
</Codenesium>*/