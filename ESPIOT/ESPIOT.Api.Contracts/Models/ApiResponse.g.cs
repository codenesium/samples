using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESPIOTNS.Api.Contracts
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

		public List<ApiDeviceResponseModel> Devices { get; private set; } = new List<ApiDeviceResponseModel>();

		public List<ApiDeviceActionResponseModel> DeviceActions { get; private set; } = new List<ApiDeviceActionResponseModel>();

		[JsonIgnore]
		public bool ShouldSerializeDevicesValue { get; private set; } = true;

		public bool ShouldSerializeDevices()
		{
			return this.ShouldSerializeDevicesValue;
		}

		public void AddDevice(ApiDeviceResponseModel item)
		{
			if (!this.Devices.Any(x => x.Id == item.Id))
			{
				this.Devices.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeDeviceActionsValue { get; private set; } = true;

		public bool ShouldSerializeDeviceActions()
		{
			return this.ShouldSerializeDeviceActionsValue;
		}

		public void AddDeviceAction(ApiDeviceActionResponseModel item)
		{
			if (!this.DeviceActions.Any(x => x.Id == item.Id))
			{
				this.DeviceActions.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.Devices.Count == 0)
			{
				this.ShouldSerializeDevicesValue = false;
			}

			if (this.DeviceActions.Count == 0)
			{
				this.ShouldSerializeDeviceActionsValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>a10d5428a0ce1d66979ecefe059ff4f8</Hash>
</Codenesium>*/