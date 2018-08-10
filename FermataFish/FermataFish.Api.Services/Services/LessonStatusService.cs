using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial class LessonStatusService : AbstractLessonStatusService, ILessonStatusService
	{
		public LessonStatusService(
			ILogger<ILessonStatusRepository> logger,
			ILessonStatusRepository lessonStatusRepository,
			IApiLessonStatusRequestModelValidator lessonStatusModelValidator,
			IBOLLessonStatusMapper bollessonStatusMapper,
			IDALLessonStatusMapper dallessonStatusMapper,
			IBOLLessonMapper bolLessonMapper,
			IDALLessonMapper dalLessonMapper
			)
			: base(logger,
			       lessonStatusRepository,
			       lessonStatusModelValidator,
			       bollessonStatusMapper,
			       dallessonStatusMapper,
			       bolLessonMapper,
			       dalLessonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ee57caa119d490426dbc5fc5e2d42170</Hash>
</Codenesium>*/