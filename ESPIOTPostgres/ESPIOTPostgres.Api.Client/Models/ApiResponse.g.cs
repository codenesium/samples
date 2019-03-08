using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESPIOTPostgresNS.Api.Client
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Devices.ForEach(x => this.AddDevice(x));
			from.DeviceActions.ForEach(x => this.AddDeviceAction(x));
		}

		public List<ApiDeviceClientResponseModel> Devices { get; private set; } = new List<ApiDeviceClientResponseModel>();

		public List<ApiDeviceActionClientResponseModel> DeviceActions { get; private set; } = new List<ApiDeviceActionClientResponseModel>();

		public void AddDevice(ApiDeviceClientResponseModel item)
		{
			if (!this.Devices.Any(x => x.Id == item.Id))
			{
				this.Devices.Add(item);
			}
		}

		public void AddDeviceAction(ApiDeviceActionClientResponseModel item)
		{
			if (!this.DeviceActions.Any(x => x.Id == item.Id))
			{
				this.DeviceActions.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>0e1c8c6ccb4ea716fe2608d83271a275</Hash>
</Codenesium>*/