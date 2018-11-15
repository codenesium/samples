using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class TeacherService : AbstractTeacherService, ITeacherService
	{
		public TeacherService(
			ILogger<ITeacherRepository> logger,
			ITeacherRepository teacherRepository,
			IApiTeacherServerRequestModelValidator teacherModelValidator,
			IBOLTeacherMapper bolTeacherMapper,
			IDALTeacherMapper dalTeacherMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper)
			: base(logger,
			       teacherRepository,
			       teacherModelValidator,
			       bolTeacherMapper,
			       dalTeacherMapper,
			       bolRateMapper,
			       dalRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8aff5c9514bf892c6553ab5c165b58c3</Hash>
</Codenesium>*/