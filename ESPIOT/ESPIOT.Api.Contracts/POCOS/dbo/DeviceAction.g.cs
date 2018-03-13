using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace ESPIOTNS.Api.Contracts
{
	public partial class POCODeviceAction
	{
		public POCODeviceAction()
		{}

		public POCODeviceAction(int deviceId,
		                        int id,
		                        string name,
		                        string @value)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.@Value = @value;

			DeviceId = new ReferenceEntity<int>(deviceId,
			                                    "Device");
		}

		public ReferenceEntity<int>DeviceId {get; set;}
		public int Id {get; set;}
		public string Name {get; set;}
		public string @Value {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeDeviceIdValue {get; set;} = true;

		public bool ShouldSerializeDeviceId()
		{
			return ShouldSerializeDeviceIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeValueValue {get; set;} = true;

		public bool ShouldSerializeValue()
		{
			return ShouldSerializeValueValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDeviceIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeValueValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>aabb19b0a70cf9a8c5a09423a6bff263</Hash>
</Codenesium>*/