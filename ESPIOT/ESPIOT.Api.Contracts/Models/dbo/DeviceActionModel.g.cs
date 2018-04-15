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

		public DeviceActionModel(
			int deviceId,
			string name,
			string @value)
		{
			this.DeviceId = deviceId.ToInt();
			this.Name = name.ToString();
			this.@Value = @value.ToString();
		}

		private int deviceId;

		[Required]
		public int DeviceId
		{
			get
			{
				return this.deviceId;
			}

			set
			{
				this.deviceId = value;
			}
		}

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		private string @value;

		[Required]
		public string @Value
		{
			get
			{
				return this.@value;
			}

			set
			{
				this.@value = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>598585aba37452ecd77463aba8ca4b03</Hash>
</Codenesium>*/