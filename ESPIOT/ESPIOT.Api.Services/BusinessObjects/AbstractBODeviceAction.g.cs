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
		                                  int deviceId,
		                                  string name,
		                                  string @value)
		{
			this.DeviceId = deviceId;
			this.Id = id;
			this.Name = name;
			this.@Value = @value;
		}

		public int DeviceId { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }

		public string @Value { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f2c283c40c426c42e33f31567b06989e</Hash>
</Codenesium>*/