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
			IDALLessonStatusMapper dallessonStatusMapper
			)
			: base(logger,
			       lessonStatusRepository,
			       lessonStatusModelValidator,
			       bollessonStatusMapper,
			       dallessonStatusMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>993045ef887e97eb065bcca02201cc1b</Hash>
</Codenesium>*/