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
	public partial class BusinessEntityService : AbstractBusinessEntityService, IBusinessEntityService
	{
		public BusinessEntityService(
			ILogger<IBusinessEntityRepository> logger,
			IBusinessEntityRepository businessEntityRepository,
			IApiBusinessEntityRequestModelValidator businessEntityModelValidator,
			IBOLBusinessEntityMapper bolbusinessEntityMapper,
			IDALBusinessEntityMapper dalbusinessEntityMapper,
			IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
			IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper,
			IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
			IDALBusinessEntityContactMapper dalBusinessEntityContactMapper,
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper
			)
			: base(logger,
			       businessEntityRepository,
			       businessEntityModelValidator,
			       bolbusinessEntityMapper,
			       dalbusinessEntityMapper,
			       bolBusinessEntityAddressMapper,
			       dalBusinessEntityAddressMapper,
			       bolBusinessEntityContactMapper,
			       dalBusinessEntityContactMapper,
			       bolPersonMapper,
			       dalPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fd0de9cae35c3d9e6867175b2c60058b</Hash>
</Codenesium>*/