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
			IDALFamilyMapper dalFamilyMapper)
			: base(logger,
			       mediator,
			       familyRepository,
			       familyModelValidator,
			       dalFamilyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1e695ff1b07c56841497202479d59869</Hash>
</Codenesium>*/