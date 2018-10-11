using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class QuoteTweetService : AbstractQuoteTweetService, IQuoteTweetService
	{
		public QuoteTweetService(
			ILogger<IQuoteTweetRepository> logger,
			IQuoteTweetRepository quoteTweetRepository,
			IApiQuoteTweetRequestModelValidator quoteTweetModelValidator,
			IBOLQuoteTweetMapper bolquoteTweetMapper,
			IDALQuoteTweetMapper dalquoteTweetMapper)
			: base(logger,
			       quoteTweetRepository,
			       quoteTweetModelValidator,
			       bolquoteTweetMapper,
			       dalquoteTweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e8ee0f4c41677dc30105adfad9dfaf42</Hash>
</Codenesium>*/