using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial class LinkTypesService : AbstractLinkTypesService, ILinkTypesService
	{
		public LinkTypesService(
			ILogger<ILinkTypesRepository> logger,
			ILinkTypesRepository linkTypesRepository,
			IApiLinkTypesRequestModelValidator linkTypesModelValidator,
			IBOLLinkTypesMapper bollinkTypesMapper,
			IDALLinkTypesMapper dallinkTypesMapper
			)
			: base(logger,
			       linkTypesRepository,
			       linkTypesModelValidator,
			       bollinkTypesMapper,
			       dallinkTypesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>93856f27c10bb8fb46b0577c64cfb523</Hash>
</Codenesium>*/