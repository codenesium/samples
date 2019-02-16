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
			IDALQuoteTweetMapper dalQuoteTweetMapper)
			: base(logger,
			       mediator,
			       quoteTweetRepository,
			       quoteTweetModelValidator,
			       dalQuoteTweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ce46818a5e6e9af03ff400ebf6c278eb</Hash>
</Codenesium>*/