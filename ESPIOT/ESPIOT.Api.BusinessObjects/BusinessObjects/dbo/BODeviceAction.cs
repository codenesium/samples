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
			IApiDeviceActionModelValidator deviceActionModelValidator)
			: base(logger, deviceActionRepository, deviceActionModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>56cb07487e411cac53a7955458bf63ac</Hash>
</Codenesium>*/