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
			IApiHandlerModelValidator handlerModelValidator)
			: base(logger, handlerRepository, handlerModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>84d4fe6dad50994d5c82f474253e3466</Hash>
</Codenesium>*/