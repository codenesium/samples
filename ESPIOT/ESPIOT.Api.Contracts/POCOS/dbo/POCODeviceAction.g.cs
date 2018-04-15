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
			int id,
			int deviceId,
			string name,
			string @value)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.@Value = @value.ToString();

			this.DeviceId = new ReferenceEntity<int>(deviceId,
			                                         nameof(ApiResponse.Devices));
		}

		public int Id { get; set; }
		public ReferenceEntity<int> DeviceId { get; set; }
		public string Name { get; set; }
		public string @Value { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDeviceIdValue { get; set; } = true;

		public bool ShouldSerializeDeviceId()
		{
			return this.ShouldSerializeDeviceIdValue;
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
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeDeviceIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeValueValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>9a65e1d1fa4eda5f5f9732aab99adbef</Hash>
</Codenesium>*/