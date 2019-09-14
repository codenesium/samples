using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESPIOTNS.Api.Client
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
    <Hash>700b098fb44c0b5f74dd0b0e0622923a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/