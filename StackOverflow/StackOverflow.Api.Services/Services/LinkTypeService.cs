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
	public partial class LinkTypeService : AbstractLinkTypeService, ILinkTypeService
	{
		public LinkTypeService(
			ILogger<ILinkTypeRepository> logger,
			ILinkTypeRepository linkTypeRepository,
			IApiLinkTypeRequestModelValidator linkTypeModelValidator,
			IBOLLinkTypeMapper bollinkTypeMapper,
			IDALLinkTypeMapper dallinkTypeMapper)
			: base(logger,
			       linkTypeRepository,
			       linkTypeModelValidator,
			       bollinkTypeMapper,
			       dallinkTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>384f2dcd885142b09ceb5996fd901951</Hash>
</Codenesium>*/