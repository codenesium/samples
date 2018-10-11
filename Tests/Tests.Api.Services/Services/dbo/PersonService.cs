using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class PersonService : AbstractPersonService, IPersonService
	{
		public PersonService(
			ILogger<IPersonRepository> logger,
			IPersonRepository personRepository,
			IApiPersonRequestModelValidator personModelValidator,
			IBOLPersonMapper bolpersonMapper,
			IDALPersonMapper dalpersonMapper)
			: base(logger,
			       personRepository,
			       personModelValidator,
			       bolpersonMapper,
			       dalpersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e58921773d657f1221f5de147d567935</Hash>
</Codenesium>*/