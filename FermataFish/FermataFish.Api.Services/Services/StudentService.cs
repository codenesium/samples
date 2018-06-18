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
                        ILogger<IStudentRepository> logger,
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
    <Hash>6d0ff1d45c36e369d9884a025481bc48</Hash>
</Codenesium>*/