using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>04e818b769b05d141dcb1c4b80a313cc</Hash>
</Codenesium>*/