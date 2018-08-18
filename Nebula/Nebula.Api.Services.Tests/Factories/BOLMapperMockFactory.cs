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

		public IBOLChainStatusMapper BOLChainStatusMapperMock { get; set; } = new BOLChainStatusMapper();

		public IBOLClaspMapper BOLClaspMapperMock { get; set; } = new BOLClaspMapper();

		public IBOLLinkMapper BOLLinkMapperMock { get; set; } = new BOLLinkMapper();

		public IBOLLinkLogMapper BOLLinkLogMapperMock { get; set; } = new BOLLinkLogMapper();

		public IBOLLinkStatusMapper BOLLinkStatusMapperMock { get; set; } = new BOLLinkStatusMapper();

		public IBOLMachineMapper BOLMachineMapperMock { get; set; } = new BOLMachineMapper();

		public IBOLMachineRefTeamMapper BOLMachineRefTeamMapperMock { get; set; } = new BOLMachineRefTeamMapper();

		public IBOLOrganizationMapper BOLOrganizationMapperMock { get; set; } = new BOLOrganizationMapper();

		public IBOLTeamMapper BOLTeamMapperMock { get; set; } = new BOLTeamMapper();

		public IBOLVersionInfoMapper BOLVersionInfoMapperMock { get; set; } = new BOLVersionInfoMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>9ec58f289168fca3f878ee97fd36858c</Hash>
</Codenesium>*/