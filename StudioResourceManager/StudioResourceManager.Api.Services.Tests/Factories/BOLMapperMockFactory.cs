using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLAdminMapper BOLAdminMapperMock { get; set; } = new BOLAdminMapper();

		public IBOLEventMapper BOLEventMapperMock { get; set; } = new BOLEventMapper();

		public IBOLEventStatusMapper BOLEventStatusMapperMock { get; set; } = new BOLEventStatusMapper();

		public IBOLEventStudentMapper BOLEventStudentMapperMock { get; set; } = new BOLEventStudentMapper();

		public IBOLEventTeacherMapper BOLEventTeacherMapperMock { get; set; } = new BOLEventTeacherMapper();

		public IBOLFamilyMapper BOLFamilyMapperMock { get; set; } = new BOLFamilyMapper();

		public IBOLRateMapper BOLRateMapperMock { get; set; } = new BOLRateMapper();

		public IBOLSpaceMapper BOLSpaceMapperMock { get; set; } = new BOLSpaceMapper();

		public IBOLSpaceFeatureMapper BOLSpaceFeatureMapperMock { get; set; } = new BOLSpaceFeatureMapper();

		public IBOLSpaceSpaceFeatureMapper BOLSpaceSpaceFeatureMapperMock { get; set; } = new BOLSpaceSpaceFeatureMapper();

		public IBOLStudentMapper BOLStudentMapperMock { get; set; } = new BOLStudentMapper();

		public IBOLStudioMapper BOLStudioMapperMock { get; set; } = new BOLStudioMapper();

		public IBOLTeacherMapper BOLTeacherMapperMock { get; set; } = new BOLTeacherMapper();

		public IBOLTeacherSkillMapper BOLTeacherSkillMapperMock { get; set; } = new BOLTeacherSkillMapper();

		public IBOLTeacherTeacherSkillMapper BOLTeacherTeacherSkillMapperMock { get; set; } = new BOLTeacherTeacherSkillMapper();

		public IBOLTenantMapper BOLTenantMapperMock { get; set; } = new BOLTenantMapper();

		public IBOLUserMapper BOLUserMapperMock { get; set; } = new BOLUserMapper();

		public IBOLVEventMapper BOLVEventMapperMock { get; set; } = new BOLVEventMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>03674a5a249a867c31dcb2a54d435e33</Hash>
</Codenesium>*/