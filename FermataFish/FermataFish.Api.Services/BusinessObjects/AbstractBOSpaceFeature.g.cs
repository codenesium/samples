using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractBOSpaceFeature : AbstractBusinessObject
	{
		public AbstractBOSpaceFeature()
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
    <Hash>b08b7ef5c5b6d4c48990051850626cd0</Hash>
</Codenesium>*/