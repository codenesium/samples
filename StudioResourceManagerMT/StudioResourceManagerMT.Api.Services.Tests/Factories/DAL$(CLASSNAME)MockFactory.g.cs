using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALAdminMapper DALAdminMapperMock { get; set; } = new DALAdminMapper();

		public IDALEventMapper DALEventMapperMock { get; set; } = new DALEventMapper();

		public IDALEventStatuMapper DALEventStatuMapperMock { get; set; } = new DALEventStatuMapper();

		public IDALEventStudentMapper DALEventStudentMapperMock { get; set; } = new DALEventStudentMapper();

		public IDALEventTeacherMapper DALEventTeacherMapperMock { get; set; } = new DALEventTeacherMapper();

		public IDALFamilyMapper DALFamilyMapperMock { get; set; } = new DALFamilyMapper();

		public IDALRateMapper DALRateMapperMock { get; set; } = new DALRateMapper();

		public IDALSpaceMapper DALSpaceMapperMock { get; set; } = new DALSpaceMapper();

		public IDALSpaceFeatureMapper DALSpaceFeatureMapperMock { get; set; } = new DALSpaceFeatureMapper();

		public IDALSpaceSpaceFeatureMapper DALSpaceSpaceFeatureMapperMock { get; set; } = new DALSpaceSpaceFeatureMapper();

		public IDALStudentMapper DALStudentMapperMock { get; set; } = new DALStudentMapper();

		public IDALStudioMapper DALStudioMapperMock { get; set; } = new DALStudioMapper();

		public IDALTeacherMapper DALTeacherMapperMock { get; set; } = new DALTeacherMapper();

		public IDALTeacherSkillMapper DALTeacherSkillMapperMock { get; set; } = new DALTeacherSkillMapper();

		public IDALTeacherTeacherSkillMapper DALTeacherTeacherSkillMapperMock { get; set; } = new DALTeacherTeacherSkillMapper();

		public IDALUserMapper DALUserMapperMock { get; set; } = new DALUserMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>19a2e13ce9462161bae4cfd376132cee</Hash>
</Codenesium>*/