using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOPipelineStepStatus : AbstractBusinessObject
	{
		public AbstractBOPipelineStepStatus()
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
    <Hash>492480bfca9558fbda181bde68a58065</Hash>
</Codenesium>*/