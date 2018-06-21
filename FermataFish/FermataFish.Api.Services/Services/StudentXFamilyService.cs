using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Services
{
        public class StudentXFamilyService : AbstractStudentXFamilyService, IStudentXFamilyService
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
                               dalstudentXFamilyMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8abbb28ab8380cf2ac10f3684b36c0a5</Hash>
</Codenesium>*/