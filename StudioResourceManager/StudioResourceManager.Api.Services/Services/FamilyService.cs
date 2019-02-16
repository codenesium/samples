using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>114d32c528ac0c5f0831a7c552fa11fb</Hash>
</Codenesium>*/