using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESPIOTNS.Api.Client
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Efmigrationshistories.ForEach(x => this.AddEfmigrationshistory(x));
			from.Devices.ForEach(x => this.AddDevice(x));
			from.DeviceActions.ForEach(x => this.AddDeviceAction(x));
		}

		public List<ApiEfmigrationshistoryClientResponseModel> Efmigrationshistories { get; private set; } = new List<ApiEfmigrationshistoryClientResponseModel>();

		public List<ApiDeviceClientResponseModel> Devices { get; private set; } = new List<ApiDeviceClientResponseModel>();

		public List<ApiDeviceActionClientResponseModel> DeviceActions { get; private set; } = new List<ApiDeviceActionClientResponseModel>();

		public void AddEfmigrationshistory(ApiEfmigrationshistoryClientResponseModel item)
		{
			if (!this.Efmigrationshistories.Any(x => x.MigrationId == item.MigrationId))
			{
				this.Efmigrationshistories.Add(item);
			}
		}

		public void AddDevice(ApiDeviceClientResponseModel item)
		{
			if (!this.Devices.Any(x => x.Id == item.Id))
			{
				this.Devices.Add(item);
			}
		}

		public void AddDeviceAction(ApiDeviceActionClientResponseModel item)
		{
			if (!this.DeviceActions.Any(x => x.Id == item.Id))
			{
				this.DeviceActions.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>59e663f2ed21ed1ef49b3a49dd1a02ed</Hash>
</Codenesium>*/