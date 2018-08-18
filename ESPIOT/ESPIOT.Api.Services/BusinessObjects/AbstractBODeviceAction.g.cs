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
    <Hash>8763f18e52d4b80e8ec348dc642b809e</Hash>
</Codenesium>*/