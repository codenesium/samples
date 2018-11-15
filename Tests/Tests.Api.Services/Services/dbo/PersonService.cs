using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class PersonService : AbstractPersonService, IPersonService
	{
		public PersonService(
			ILogger<IPersonRepository> logger,
			IPersonRepository personRepository,
			IApiPersonServerRequestModelValidator personModelValidator,
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper)
			: base(logger,
			       personRepository,
			       personModelValidator,
			       bolPersonMapper,
			       dalPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9c6984f4998cd338194ee45c10dd6428</Hash>
</Codenesium>*/