using Moq;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALAdminMapper DALAdminMapperMock { get; set; } = new DALAdminMapper();

		public IDALEventMapper DALEventMapperMock { get; set; } = new DALEventMapper();

		public IDALEventStatusMapper DALEventStatusMapperMock { get; set; } = new DALEventStatusMapper();

		public IDALFamilyMapper DALFamilyMapperMock { get; set; } = new DALFamilyMapper();

		public IDALRateMapper DALRateMapperMock { get; set; } = new DALRateMapper();

		public IDALSpaceMapper DALSpaceMapperMock { get; set; } = new DALSpaceMapper();

		public IDALSpaceFeatureMapper DALSpaceFeatureMapperMock { get; set; } = new DALSpaceFeatureMapper();

		public IDALStudentMapper DALStudentMapperMock { get; set; } = new DALStudentMapper();

		public IDALStudioMapper DALStudioMapperMock { get; set; } = new DALStudioMapper();

		public IDALTeacherMapper DALTeacherMapperMock { get; set; } = new DALTeacherMapper();

		public IDALTeacherSkillMapper DALTeacherSkillMapperMock { get; set; } = new DALTeacherSkillMapper();

		public IDALTenantMapper DALTenantMapperMock { get; set; } = new DALTenantMapper();

		public IDALUserMapper DALUserMapperMock { get; set; } = new DALUserMapper();

		public IDALVEventMapper DALVEventMapperMock { get; set; } = new DALVEventMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a284a927b12619047b4400ad8705816a</Hash>
</Codenesium>*/