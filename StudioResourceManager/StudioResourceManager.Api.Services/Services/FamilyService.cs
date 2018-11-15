using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class FamilyService : AbstractFamilyService, IFamilyService
	{
		public FamilyService(
			ILogger<IFamilyRepository> logger,
			IFamilyRepository familyRepository,
			IApiFamilyServerRequestModelValidator familyModelValidator,
			IBOLFamilyMapper bolFamilyMapper,
			IDALFamilyMapper dalFamilyMapper,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper)
			: base(logger,
			       familyRepository,
			       familyModelValidator,
			       bolFamilyMapper,
			       dalFamilyMapper,
			       bolStudentMapper,
			       dalStudentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e0a139670c6ff5390456267a1d669541</Hash>
</Codenesium>*/