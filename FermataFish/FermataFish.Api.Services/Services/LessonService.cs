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
    <Hash>9706e60cb969fde3e8e5cda8e71256a2</Hash>
</Codenesium>*/