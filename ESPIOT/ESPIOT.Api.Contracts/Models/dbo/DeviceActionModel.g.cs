using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace ESPIOTNS.Api.Contracts
{
	public partial class DeviceActionModel
	{
		public DeviceActionModel()
		{}

		public DeviceActionModel(int deviceId,
		                         int id,
		                         string name,
		                         string @value)
		{
			this.DeviceId = deviceId.ToInt();
			this.Id = id.ToInt();
			this.Name = name;
			this.@Value = @value;
		}

		public DeviceActionModel(POCODeviceAction poco)
		{
			this.Id = poco.Id.ToInt();
			this.Name = poco.Name;
			this.@Value = poco.@Value;

			DeviceId = poco.DeviceId.Value.ToInt();
		}

		private int _deviceId;
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

		private int _id;
		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				this._id = value;
			}
		}

		private string _name;
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
    <Hash>ad55a209c92959f99dae053c389de345</Hash>
</Codenesium>*/