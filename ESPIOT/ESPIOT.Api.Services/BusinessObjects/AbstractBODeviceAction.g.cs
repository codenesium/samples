using Codenesium.DataConversionExtensions;
using System;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractBODeviceAction : AbstractBusinessObject
	{
		public AbstractBODeviceAction()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string @value,
		                                  int deviceId,
		                                  string name)
		{
			this.@Value = @value;
			this.DeviceId = deviceId;
			this.Id = id;
			this.Name = name;
		}

		public int DeviceId { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }

		public string @Value { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6c93531289037c1ce38f330346e3f18a</Hash>
</Codenesium>*/