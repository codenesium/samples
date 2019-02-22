using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class PersonTypeService : AbstractPersonTypeService, IPersonTypeService
	{
		public PersonTypeService(
			ILogger<IPersonTypeRepository> logger,
			IMediator mediator,
			IPersonTypeRepository personTypeRepository,
			IApiPersonTypeServerRequestModelValidator personTypeModelValidator,
			IDALPersonTypeMapper dalPersonTypeMapper,
			IDALCallPersonMapper dalCallPersonMapper)
			: base(logger,
			       mediator,
			       personTypeRepository,
			       personTypeModelValidator,
			       dalPersonTypeMapper,
			       dalCallPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f07b11ae62e74391b478ebee787010ac</Hash>
</Codenesium>*/