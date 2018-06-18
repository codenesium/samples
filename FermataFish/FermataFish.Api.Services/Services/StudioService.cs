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
        public class StudioService: AbstractStudioService, IStudioService
        {
                public StudioService(
                        ILogger<IStudioRepository> logger,
                        IStudioRepository studioRepository,
                        IApiStudioRequestModelValidator studioModelValidator,
                        IBOLStudioMapper bolstudioMapper,
                        IDALStudioMapper dalstudioMapper
                        ,
                        IBOLAdminMapper bolAdminMapper,
                        IDALAdminMapper dalAdminMapper
                        ,
                        IBOLFamilyMapper bolFamilyMapper,
                        IDALFamilyMapper dalFamilyMapper
                        ,
                        IBOLLessonMapper bolLessonMapper,
                        IDALLessonMapper dalLessonMapper
                        ,
                        IBOLLessonStatusMapper bolLessonStatusMapper,
                        IDALLessonStatusMapper dalLessonStatusMapper
                        ,
                        IBOLSpaceMapper bolSpaceMapper,
                        IDALSpaceMapper dalSpaceMapper
                        ,
                        IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
                        IDALSpaceFeatureMapper dalSpaceFeatureMapper
                        ,
                        IBOLStudentMapper bolStudentMapper,
                        IDALStudentMapper dalStudentMapper
                        ,
                        IBOLTeacherMapper bolTeacherMapper,
                        IDALTeacherMapper dalTeacherMapper
                        ,
                        IBOLTeacherSkillMapper bolTeacherSkillMapper,
                        IDALTeacherSkillMapper dalTeacherSkillMapper

                        )
                        : base(logger,
                               studioRepository,
                               studioModelValidator,
                               bolstudioMapper,
                               dalstudioMapper
                               ,
                               bolAdminMapper,
                               dalAdminMapper
                               ,
                               bolFamilyMapper,
                               dalFamilyMapper
                               ,
                               bolLessonMapper,
                               dalLessonMapper
                               ,
                               bolLessonStatusMapper,
                               dalLessonStatusMapper
                               ,
                               bolSpaceMapper,
                               dalSpaceMapper
                               ,
                               bolSpaceFeatureMapper,
                               dalSpaceFeatureMapper
                               ,
                               bolStudentMapper,
                               dalStudentMapper
                               ,
                               bolTeacherMapper,
                               dalTeacherMapper
                               ,
                               bolTeacherSkillMapper,
                               dalTeacherSkillMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>d88e003d908a77157e02d7fabcfa5be2</Hash>
</Codenesium>*/