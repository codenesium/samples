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
			IDALQuoteTweetMapper dalquoteTweetMapper
			)
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
    <Hash>c2830fbb3716b6e6a67fcf3d13e2463c</Hash>
</Codenesium>*/