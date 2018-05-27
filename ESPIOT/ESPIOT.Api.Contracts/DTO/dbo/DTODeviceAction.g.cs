using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace ESPIOTNS.Api.Contracts
{
	public partial class DTODeviceAction: AbstractDTO
	{
		public DTODeviceAction() : base()
		{}

		public void SetProperties(int id,
		                          int deviceId,
		                          string name,
		                          string @value)
		{
			this.DeviceId = deviceId.ToInt();
			this.Id = id.ToInt();
			this.Name = name;
			this.@Value = @value;
		}

		public int DeviceId { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public string @Value { get; set; }
	}
}

/*<Codenesium>
    <Hash>379bcfd5ca33ab11d9b73617ad653e33</Hash>
</Codenesium>*/