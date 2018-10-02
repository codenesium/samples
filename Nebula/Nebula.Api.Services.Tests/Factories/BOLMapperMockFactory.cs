using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLChainMapper BOLChainMapperMock { get; set; } = new BOLChainMapper();

		public IBOLChainStatuMapper BOLChainStatuMapperMock { get; set; } = new BOLChainStatuMapper();

		public IBOLClaspMapper BOLClaspMapperMock { get; set; } = new BOLClaspMapper();

		public IBOLLinkMapper BOLLinkMapperMock { get; set; } = new BOLLinkMapper();

		public IBOLLinkLogMapper BOLLinkLogMapperMock { get; set; } = new BOLLinkLogMapper();

		public IBOLLinkStatuMapper BOLLinkStatuMapperMock { get; set; } = new BOLLinkStatuMapper();

		public IBOLMachineMapper BOLMachineMapperMock { get; set; } = new BOLMachineMapper();

		public IBOLMachineRefTeamMapper BOLMachineRefTeamMapperMock { get; set; } = new BOLMachineRefTeamMapper();

		public IBOLOrganizationMapper BOLOrganizationMapperMock { get; set; } = new BOLOrganizationMapper();

		public IBOLSysdiagramMapper BOLSysdiagramMapperMock { get; set; } = new BOLSysdiagramMapper();

		public IBOLTeamMapper BOLTeamMapperMock { get; set; } = new BOLTeamMapper();

		public IBOLVersionInfoMapper BOLVersionInfoMapperMock { get; set; } = new BOLVersionInfoMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>9825fdcf498d3f4dfd13244257519fb9</Hash>
</Codenesium>*/