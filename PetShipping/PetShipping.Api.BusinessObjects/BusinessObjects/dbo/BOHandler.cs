using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class BOHandler: AbstractBOHandler, IBOHandler
	{
		public BOHandler(
			ILogger<HandlerRepository> logger,
			IHandlerRepository handlerRepository,
			IApiHandlerRequestModelValidator handlerModelValidator,
			IBOLHandlerMapper handlerMapper)
			: base(logger, handlerRepository, handlerModelValidator, handlerMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>5c319a5e43fc37cd0df14392ef050c18</Hash>
</Codenesium>*/