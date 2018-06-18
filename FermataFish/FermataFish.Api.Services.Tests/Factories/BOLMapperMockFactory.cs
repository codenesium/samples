using Moq;
using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services.Tests
{
        public class BOLMapperMockFactory
        {
                public IBOLAdminMapper BOLAdminMapperMock { get; set; } = new BOLAdminMapper();

                public IBOLFamilyMapper BOLFamilyMapperMock { get; set; } = new BOLFamilyMapper();

                public IBOLLessonMapper BOLLessonMapperMock { get; set; } = new BOLLessonMapper();

                public IBOLLessonStatusMapper BOLLessonStatusMapperMock { get; set; } = new BOLLessonStatusMapper();

                public IBOLLessonXStudentMapper BOLLessonXStudentMapperMock { get; set; } = new BOLLessonXStudentMapper();

                public IBOLLessonXTeacherMapper BOLLessonXTeacherMapperMock { get; set; } = new BOLLessonXTeacherMapper();

                public IBOLRateMapper BOLRateMapperMock { get; set; } = new BOLRateMapper();

                public IBOLSpaceMapper BOLSpaceMapperMock { get; set; } = new BOLSpaceMapper();

                public IBOLSpaceFeatureMapper BOLSpaceFeatureMapperMock { get; set; } = new BOLSpaceFeatureMapper();

                public IBOLSpaceXSpaceFeatureMapper BOLSpaceXSpaceFeatureMapperMock { get; set; } = new BOLSpaceXSpaceFeatureMapper();

                public IBOLStateMapper BOLStateMapperMock { get; set; } = new BOLStateMapper();

                public IBOLStudentMapper BOLStudentMapperMock { get; set; } = new BOLStudentMapper();

                public IBOLStudentXFamilyMapper BOLStudentXFamilyMapperMock { get; set; } = new BOLStudentXFamilyMapper();

                public IBOLStudioMapper BOLStudioMapperMock { get; set; } = new BOLStudioMapper();

                public IBOLTeacherMapper BOLTeacherMapperMock { get; set; } = new BOLTeacherMapper();

                public IBOLTeacherSkillMapper BOLTeacherSkillMapperMock { get; set; } = new BOLTeacherSkillMapper();

                public IBOLTeacherXTeacherSkillMapper BOLTeacherXTeacherSkillMapperMock { get; set; } = new BOLTeacherXTeacherSkillMapper();

                public BOLMapperMockFactory()
                {
                }
        }
}

/*<Codenesium>
    <Hash>efdbc09d79aacae54af2799e572ea596</Hash>
</Codenesium>*/