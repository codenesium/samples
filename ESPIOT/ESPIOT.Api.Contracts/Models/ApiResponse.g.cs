using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ESPIOTNS.Api.Contracts
{
	public class ReferenceEntity<T>
	{
		[JsonProperty(PropertyName = "Value")]
		public T Value { get; set; }

		[JsonProperty(PropertyName = "Object")]
		public string ReferenceObjectName { get; set; }

		public ReferenceEntity(T value, string referenceObjectName)
		{
			this.Value = value;
			this.ReferenceObjectName = referenceObjectName;
		}
	}

	public partial class ApiResponse
	{
		public ApiResponse()
		{}

		public void Merge(ApiResponse from)
		{
			from.Devices.ForEach(x => this.AddDevice(x));
			from.DeviceActions.ForEach(x => this.AddDeviceAction(x));
		}

		public List<ApiDeviceResponseModel> Devices { get; private set; } = new List<ApiDeviceResponseModel>();

		public List<ApiDeviceActionResponseModel> DeviceActions { get; private set; } = new List<ApiDeviceActionResponseModel>();

		[JsonIgnore]
		public bool ShouldSerializeDevicesValue { get; set; } = true;

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
		public bool ShouldSerializeDeviceActionsValue { get; set; } = true;

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
    <Hash>31b23907b054696875e7d0b003aec83a</Hash>
</Codenesium>*/