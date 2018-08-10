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
	public partial class PersonService : AbstractPersonService, IPersonService
	{
		public PersonService(
			ILogger<IPersonRepository> logger,
			IPersonRepository personRepository,
			IApiPersonRequestModelValidator personModelValidator,
			IBOLPersonMapper bolpersonMapper,
			IDALPersonMapper dalpersonMapper,
			IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
			IDALBusinessEntityContactMapper dalBusinessEntityContactMapper,
			IBOLEmailAddressMapper bolEmailAddressMapper,
			IDALEmailAddressMapper dalEmailAddressMapper,
			IBOLPasswordMapper bolPasswordMapper,
			IDALPasswordMapper dalPasswordMapper,
			IBOLPersonPhoneMapper bolPersonPhoneMapper,
			IDALPersonPhoneMapper dalPersonPhoneMapper
			)
			: base(logger,
			       personRepository,
			       personModelValidator,
			       bolpersonMapper,
			       dalpersonMapper,
			       bolBusinessEntityContactMapper,
			       dalBusinessEntityContactMapper,
			       bolEmailAddressMapper,
			       dalEmailAddressMapper,
			       bolPasswordMapper,
			       dalPasswordMapper,
			       bolPersonPhoneMapper,
			       dalPersonPhoneMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f795b67b2b18606b52b85e43f11d3265</Hash>
</Codenesium>*/