using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class ChainService : AbstractChainService, IChainService
	{
		public ChainService(
			ILogger<IChainRepository> logger,
			IChainRepository chainRepository,
			IApiChainServerRequestModelValidator chainModelValidator,
			IBOLChainMapper bolChainMapper,
			IDALChainMapper dalChainMapper,
			IBOLClaspMapper bolClaspMapper,
			IDALClaspMapper dalClaspMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper)
			: base(logger,
			       chainRepository,
			       chainModelValidator,
			       bolChainMapper,
			       dalChainMapper,
			       bolClaspMapper,
			       dalClaspMapper,
			       bolLinkMapper,
			       dalLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a24320c2b50cf77f81793b19747f6a9a</Hash>
</Codenesium>*/