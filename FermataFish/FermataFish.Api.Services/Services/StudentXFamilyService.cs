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
                        ILogger<IStudentXFamilyRepository> logger,
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
    <Hash>aa64578b539251b14e4359e979b09a3b</Hash>
</Codenesium>*/