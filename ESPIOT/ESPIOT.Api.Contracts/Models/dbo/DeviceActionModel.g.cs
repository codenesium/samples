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
    <Hash>f297f659496d6503b109998c9bb46fe1</Hash>
</Codenesium>*/