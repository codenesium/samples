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
                        IDALStudentMapper dalstudentMapper)
                        : base(logger,
                               studentRepository,
                               studentModelValidator,
                               bolstudentMapper,
                               dalstudentMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>54c7dab7590e39e1324526a37b8b37f1</Hash>
</Codenesium>*/