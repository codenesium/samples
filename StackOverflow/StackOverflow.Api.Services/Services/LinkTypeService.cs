using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class LinkTypeService : AbstractLinkTypeService, ILinkTypeService
	{
		public LinkTypeService(
			ILogger<ILinkTypeRepository> logger,
			ILinkTypeRepository linkTypeRepository,
			IApiLinkTypeServerRequestModelValidator linkTypeModelValidator,
			IBOLLinkTypeMapper bolLinkTypeMapper,
			IDALLinkTypeMapper dalLinkTypeMapper)
			: base(logger,
			       linkTypeRepository,
			       linkTypeModelValidator,
			       bolLinkTypeMapper,
			       dalLinkTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>24b50396f0a275536f7899dd323f0487</Hash>
</Codenesium>*/