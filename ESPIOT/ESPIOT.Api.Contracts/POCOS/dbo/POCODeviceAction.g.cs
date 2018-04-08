using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace ESPIOTNS.Api.Contracts
{
	public partial class POCODeviceAction
	{
		public POCODeviceAction()
		{}

		public POCODeviceAction(int id,
		                        int deviceId,
		                        string name,
		                        string @value)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.@Value = @value;

			DeviceId = new ReferenceEntity<int>(deviceId,
			                                    "Device");
		}

		public int Id {get; set;}
		public ReferenceEntity<int>DeviceId {get; set;}
		public string Name {get; set;}
		public string @Value {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDeviceIdValue {get; set;} = true;

		public bool ShouldSerializeDeviceId()
		{
			return ShouldSerializeDeviceIdValue;
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
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeDeviceIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeValueValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>2bd3059bf46526632747ecb55831ef27</Hash>
</Codenesium>*/