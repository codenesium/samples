using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class PersonService : AbstractPersonService, IPersonService
	{
		public PersonService(
			ILogger<IPersonRepository> logger,
			IPersonRepository personRepository,
			IApiPersonServerRequestModelValidator personModelValidator,
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper,
			IBOLPasswordMapper bolPasswordMapper,
			IDALPasswordMapper dalPasswordMapper)
			: base(logger,
			       personRepository,
			       personModelValidator,
			       bolPersonMapper,
			       dalPersonMapper,
			       bolPasswordMapper,
			       dalPasswordMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>df0afcfedbeb604c8d8b3cb2af824b43</Hash>
</Codenesium>*/