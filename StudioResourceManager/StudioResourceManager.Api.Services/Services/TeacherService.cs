using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>e77c6275c6193fc47e7384510f2990bf</Hash>
</Codenesium>*/