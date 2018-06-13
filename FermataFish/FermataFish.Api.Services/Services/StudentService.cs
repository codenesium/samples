using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class StudentService: AbstractStudentService, IStudentService
        {
                public StudentService(
                        ILogger<StudentRepository> logger,
                        IStudentRepository studentRepository,
                        IApiStudentRequestModelValidator studentModelValidator,
                        IBOLStudentMapper bolstudentMapper,
                        IDALStudentMapper dalstudentMapper
                        ,
                        IBOLLessonXStudentMapper bolLessonXStudentMapper,
                        IDALLessonXStudentMapper dalLessonXStudentMapper
                        ,
                        IBOLLessonXTeacherMapper bolLessonXTeacherMapper,
                        IDALLessonXTeacherMapper dalLessonXTeacherMapper
                        ,
                        IBOLStudentXFamilyMapper bolStudentXFamilyMapper,
                        IDALStudentXFamilyMapper dalStudentXFamilyMapper

                        )
                        : base(logger,
                               studentRepository,
                               studentModelValidator,
                               bolstudentMapper,
                               dalstudentMapper
                               ,
                               bolLessonXStudentMapper,
                               dalLessonXStudentMapper
                               ,
                               bolLessonXTeacherMapper,
                               dalLessonXTeacherMapper
                               ,
                               bolStudentXFamilyMapper,
                               dalStudentXFamilyMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>196226ba05ff6146b7428dc795d45b96</Hash>
</Codenesium>*/