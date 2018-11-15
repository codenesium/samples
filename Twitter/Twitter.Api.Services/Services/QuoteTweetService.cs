using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class QuoteTweetService : AbstractQuoteTweetService, IQuoteTweetService
	{
		public QuoteTweetService(
			ILogger<IQuoteTweetRepository> logger,
			IQuoteTweetRepository quoteTweetRepository,
			IApiQuoteTweetServerRequestModelValidator quoteTweetModelValidator,
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper)
			: base(logger,
			       quoteTweetRepository,
			       quoteTweetModelValidator,
			       bolQuoteTweetMapper,
			       dalQuoteTweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>eed0cedf6c0162d443a3484f74137bac</Hash>
</Codenesium>*/