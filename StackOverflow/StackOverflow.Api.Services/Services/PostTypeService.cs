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
	public partial class PostTypeService : AbstractPostTypeService, IPostTypeService
	{
		public PostTypeService(
			ILogger<IPostTypeRepository> logger,
			IPostTypeRepository postTypeRepository,
			IApiPostTypeRequestModelValidator postTypeModelValidator,
			IBOLPostTypeMapper bolpostTypeMapper,
			IDALPostTypeMapper dalpostTypeMapper)
			: base(logger,
			       postTypeRepository,
			       postTypeModelValidator,
			       bolpostTypeMapper,
			       dalpostTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2ae59af2f30f9f9636d0e4e18537366c</Hash>
</Codenesium>*/