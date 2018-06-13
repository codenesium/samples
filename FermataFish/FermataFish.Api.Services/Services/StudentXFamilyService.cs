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
        public class StudentXFamilyService: AbstractStudentXFamilyService, IStudentXFamilyService
        {
                public StudentXFamilyService(
                        ILogger<StudentXFamilyRepository> logger,
                        IStudentXFamilyRepository studentXFamilyRepository,
                        IApiStudentXFamilyRequestModelValidator studentXFamilyModelValidator,
                        IBOLStudentXFamilyMapper bolstudentXFamilyMapper,
                        IDALStudentXFamilyMapper dalstudentXFamilyMapper

                        )
                        : base(logger,
                               studentXFamilyRepository,
                               studentXFamilyModelValidator,
                               bolstudentXFamilyMapper,
                               dalstudentXFamilyMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>45fb04f308f7f32bf7e8129702189e27</Hash>
</Codenesium>*/