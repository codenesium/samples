using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLChainStatusMapper BOLChainStatusMapperMock { get; set; } = new BOLChainStatusMapper();

		public IBOLLinkMapper BOLLinkMapperMock { get; set; } = new BOLLinkMapper();

		public IBOLLinkLogMapper BOLLinkLogMapperMock { get; set; } = new BOLLinkLogMapper();

		public IBOLLinkStatusMapper BOLLinkStatusMapperMock { get; set; } = new BOLLinkStatusMapper();

		public IBOLMachineMapper BOLMachineMapperMock { get; set; } = new BOLMachineMapper();

		public IBOLOrganizationMapper BOLOrganizationMapperMock { get; set; } = new BOLOrganizationMapper();

		public IBOLTeamMapper BOLTeamMapperMock { get; set; } = new BOLTeamMapper();

		public IBOLVersionInfoMapper BOLVersionInfoMapperMock { get; set; } = new BOLVersionInfoMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>ac62eece9d3d5452098db3c3dfae6665</Hash>
</Codenesium>*/