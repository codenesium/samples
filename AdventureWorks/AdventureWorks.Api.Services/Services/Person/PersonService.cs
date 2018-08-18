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
    <Hash>569a9434248983b5dde0b4e5d2e2bb09</Hash>
</Codenesium>*/