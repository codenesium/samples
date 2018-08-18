using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class BusinessEntityContactService : AbstractBusinessEntityContactService, IBusinessEntityContactService
	{
		public BusinessEntityContactService(
			ILogger<IBusinessEntityContactRepository> logger,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IApiBusinessEntityContactRequestModelValidator businessEntityContactModelValidator,
			IBOLBusinessEntityContactMapper bolbusinessEntityContactMapper,
			IDALBusinessEntityContactMapper dalbusinessEntityContactMapper
			)
			: base(logger,
			       businessEntityContactRepository,
			       businessEntityContactModelValidator,
			       bolbusinessEntityContactMapper,
			       dalbusinessEntityContactMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>471f5ceafce407c1acbe7cd67317df69</Hash>
</Codenesium>*/