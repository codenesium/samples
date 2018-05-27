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
    <Hash>615b14a4bb36f44329f484934d3b14f4</Hash>
</Codenesium>*/