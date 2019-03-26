using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class FamilyService : AbstractFamilyService, IFamilyService
	{
		public FamilyService(
			ILogger<IFamilyRepository> logger,
			IMediator mediator,
			IFamilyRepository familyRepository,
			IApiFamilyServerRequestModelValidator familyModelValidator,
			IDALFamilyMapper dalFamilyMapper,
			IDALStudentMapper dalStudentMapper)
			: base(logger,
			       mediator,
			       familyRepository,
			       familyModelValidator,
			       dalFamilyMapper,
			       dalStudentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a3009675b943699ae4a2f24bb3a71ad6</Hash>
</Codenesium>*/