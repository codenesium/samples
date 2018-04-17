using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.BusinessObjects
{
	public class BODeviceAction: AbstractBODeviceAction, IBODeviceAction
	{
		public BODeviceAction(
			ILogger<DeviceActionRepository> logger,
			IDeviceActionRepository deviceActionRepository,
			IDeviceActionModelValidator deviceActionModelValidator)
			: base(logger, deviceActionRepository, deviceActionModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>1c2323b712eec52b727467fd80a43696</Hash>
</Codenesium>*/