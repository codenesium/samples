using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace ESPIOTNS.Api.Contracts
{
	public partial class POCODeviceAction
	{
		public POCODeviceAction()
		{}

		public POCODeviceAction(
			int deviceId,
			int id,
			string name,
			string @value)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.@Value = @value;

			this.DeviceId = new ReferenceEntity<int>(deviceId,
			                                         nameof(ApiResponse.Devices));
		}

		public ReferenceEntity<int> DeviceId { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public string @Value { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDeviceIdValue { get; set; } = true;

		public bool ShouldSerializeDeviceId()
		{
			return this.ShouldSerializeDeviceIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeValueValue { get; set; } = true;

		public bool ShouldSerializeValue()
		{
			return this.ShouldSerializeValueValue;
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
    <Hash>d362d631ce75c76ae2c0da9f62fac12e</Hash>
</Codenesium>*/