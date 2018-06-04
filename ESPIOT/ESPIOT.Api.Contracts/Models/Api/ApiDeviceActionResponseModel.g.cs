using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace ESPIOTNS.Api.Contracts
{
	public partial class ApiDeviceActionResponseModel: AbstractApiResponseModel
	{
		public ApiDeviceActionResponseModel() : base()
		{}

		public void SetProperties(
			int deviceId,
			int id,
			string name,
			string @value)
		{
			this.DeviceId = deviceId.ToInt();
			this.Id = id.ToInt();
			this.Name = name;
			this.@Value = @value;

			this.DeviceIdEntity = nameof(ApiResponse.Devices);
		}

		public int DeviceId { get; private set; }
		public string DeviceIdEntity { get; set; }
		public int Id { get; private set; }
		public string Name { get; private set; }
		public string @Value { get; private set; }

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
    <Hash>ae406d19c0928464803455ebea2dc4d8</Hash>
</Codenesium>*/