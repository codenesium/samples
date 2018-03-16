using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace ESPIOTNS.Api.Contracts
{
	public partial class DeviceActionModel
	{
		public DeviceActionModel()
		{}

		public DeviceActionModel(int deviceId,
		                         string name,
		                         string @value)
		{
			this.DeviceId = deviceId.ToInt();
			this.Name = name;
			this.@Value = @value;
		}

		public DeviceActionModel(POCODeviceAction poco)
		{
			this.Name = poco.Name;
			this.@Value = poco.@Value;

			this.DeviceId = poco.DeviceId.Value.ToInt();
		}

		private int _deviceId;
		[Required]
		public int DeviceId
		{
			get
			{
				return _deviceId;
			}
			set
			{
				this._deviceId = value;
			}
		}

		private string _name;
		[Required]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
			}
		}

		private string @value;
		[Required]
		public string @Value
		{
			get
			{
				return @value;
			}
			set
			{
				this.@value = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>8a844cad43a71b824b0ad08614139528</Hash>
</Codenesium>*/