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

		public IDALEventStatusMapper DALEventStatusMapperMock { get; set; } = new DALEventStatusMapper();

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

		public IDALTenantMapper DALTenantMapperMock { get; set; } = new DALTenantMapper();

		public IDALUserMapper DALUserMapperMock { get; set; } = new DALUserMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>833baf8919f9a7e21ba3c02ff70d8a94</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/