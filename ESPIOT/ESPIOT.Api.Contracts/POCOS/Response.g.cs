using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
namespace ESPIOTNS.Api.Contracts
{
	public class ReferenceEntity<T>
	{
		public T Value { get; set; }
		public string Href
		{
			get
			{
				return $"/{this.ReferenceObjectName}/{this.Value.ToString()}";
			}
		}
		public string ReferenceObjectName { get; set; }

		public ReferenceEntity(T value, string referenceObjectName)
		{
			this.Value = value;
			this.ReferenceObjectName = referenceObjectName;
		}
	}

	public partial class Response
	{
		public Response()
		{}
		public List<POCODevice> Devices { get; private set; }  = new  List<POCODevice>();
		public List<POCODeviceAction> DeviceActions { get; private set; }  = new  List<POCODeviceAction>();

		[JsonIgnore]
		public bool ShouldSerializeDevicesValue {get; set;} = true;

		public bool ShouldSerializeDevices()
		{
			return ShouldSerializeDevicesValue;
		}

		public void AddDevice(POCODevice item)
		{
			if (!this.Devices.Any(x => x.Id == item.Id))
			{
				this.Devices.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeDeviceActionsValue {get; set;} = true;

		public bool ShouldSerializeDeviceActions()
		{
			return ShouldSerializeDeviceActionsValue;
		}

		public void AddDeviceAction(POCODeviceAction item)
		{
			if (!this.DeviceActions.Any(x => x.Id == item.Id))
			{
				this.DeviceActions.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if(this.Devices.Count == 0)
			{
				this.ShouldSerializeDevicesValue = false;
			}
			if(this.DeviceActions.Count == 0)
			{
				this.ShouldSerializeDeviceActionsValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>2359eb95b373442f1a4e6c7fd22d7756</Hash>
</Codenesium>*/