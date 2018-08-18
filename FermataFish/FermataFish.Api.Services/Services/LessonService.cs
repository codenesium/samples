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
	public partial class LessonService : AbstractLessonService, ILessonService
	{
		public LessonService(
			ILogger<ILessonRepository> logger,
			ILessonRepository lessonRepository,
			IApiLessonRequestModelValidator lessonModelValidator,
			IBOLLessonMapper bollessonMapper,
			IDALLessonMapper dallessonMapper,
			IBOLLessonXStudentMapper bolLessonXStudentMapper,
			IDALLessonXStudentMapper dalLessonXStudentMapper,
			IBOLLessonXTeacherMapper bolLessonXTeacherMapper,
			IDALLessonXTeacherMapper dalLessonXTeacherMapper
			)
			: base(logger,
			       lessonRepository,
			       lessonModelValidator,
			       bollessonMapper,
			       dallessonMapper,
			       bolLessonXStudentMapper,
			       dalLessonXStudentMapper,
			       bolLessonXTeacherMapper,
			       dalLessonXTeacherMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>23033db3e88726b9c88d97ae5c8a1ff6</Hash>
</Codenesium>*/