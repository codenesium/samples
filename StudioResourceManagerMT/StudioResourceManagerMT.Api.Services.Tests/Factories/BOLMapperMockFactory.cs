using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLAdminMapper BOLAdminMapperMock { get; set; } = new BOLAdminMapper();

		public IBOLEventMapper BOLEventMapperMock { get; set; } = new BOLEventMapper();

		public IBOLEventStatuMapper BOLEventStatuMapperMock { get; set; } = new BOLEventStatuMapper();

		public IBOLFamilyMapper BOLFamilyMapperMock { get; set; } = new BOLFamilyMapper();

		public IBOLRateMapper BOLRateMapperMock { get; set; } = new BOLRateMapper();

		public IBOLSpaceMapper BOLSpaceMapperMock { get; set; } = new BOLSpaceMapper();

		public IBOLSpaceFeatureMapper BOLSpaceFeatureMapperMock { get; set; } = new BOLSpaceFeatureMapper();

		public IBOLStudentMapper BOLStudentMapperMock { get; set; } = new BOLStudentMapper();

		public IBOLStudioMapper BOLStudioMapperMock { get; set; } = new BOLStudioMapper();

		public IBOLTeacherMapper BOLTeacherMapperMock { get; set; } = new BOLTeacherMapper();

		public IBOLTeacherSkillMapper BOLTeacherSkillMapperMock { get; set; } = new BOLTeacherSkillMapper();

		public IBOLUserMapper BOLUserMapperMock { get; set; } = new BOLUserMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8adf1d92ddc879408c59c033c20938a4</Hash>
</Codenesium>*/