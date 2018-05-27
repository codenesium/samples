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
			IApiDeviceActionRequestModelValidator deviceActionModelValidator,
			IBOLDeviceActionMapper deviceActionMapper)
			: base(logger, deviceActionRepository, deviceActionModelValidator, deviceActionMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>24eed89966ae28caabfd929445bb7b02</Hash>
</Codenesium>*/