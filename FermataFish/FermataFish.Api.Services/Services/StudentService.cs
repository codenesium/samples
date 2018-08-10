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
	public partial class StudentService : AbstractStudentService, IStudentService
	{
		public StudentService(
			ILogger<IStudentRepository> logger,
			IStudentRepository studentRepository,
			IApiStudentRequestModelValidator studentModelValidator,
			IBOLStudentMapper bolstudentMapper,
			IDALStudentMapper dalstudentMapper,
			IBOLLessonXStudentMapper bolLessonXStudentMapper,
			IDALLessonXStudentMapper dalLessonXStudentMapper,
			IBOLLessonXTeacherMapper bolLessonXTeacherMapper,
			IDALLessonXTeacherMapper dalLessonXTeacherMapper,
			IBOLStudentXFamilyMapper bolStudentXFamilyMapper,
			IDALStudentXFamilyMapper dalStudentXFamilyMapper
			)
			: base(logger,
			       studentRepository,
			       studentModelValidator,
			       bolstudentMapper,
			       dalstudentMapper,
			       bolLessonXStudentMapper,
			       dalLessonXStudentMapper,
			       bolLessonXTeacherMapper,
			       dalLessonXTeacherMapper,
			       bolStudentXFamilyMapper,
			       dalStudentXFamilyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>916802789614d1c32b1f3d405383158b</Hash>
</Codenesium>*/