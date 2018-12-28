using MediatR;
using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class QuoteTweetService : AbstractQuoteTweetService, IQuoteTweetService
	{
		public QuoteTweetService(
			ILogger<IQuoteTweetRepository> logger,
			IMediator mediator,
			IQuoteTweetRepository quoteTweetRepository,
			IApiQuoteTweetServerRequestModelValidator quoteTweetModelValidator,
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper)
			: base(logger,
			       mediator,
			       quoteTweetRepository,
			       quoteTweetModelValidator,
			       bolQuoteTweetMapper,
			       dalQuoteTweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6b4ed8a20b0c9b3f3900632da728eadd</Hash>
</Codenesium>*/