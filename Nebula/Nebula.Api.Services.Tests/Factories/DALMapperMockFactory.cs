using Moq;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALChainStatusMapper DALChainStatusMapperMock { get; set; } = new DALChainStatusMapper();

		public IDALLinkMapper DALLinkMapperMock { get; set; } = new DALLinkMapper();

		public IDALLinkLogMapper DALLinkLogMapperMock { get; set; } = new DALLinkLogMapper();

		public IDALLinkStatusMapper DALLinkStatusMapperMock { get; set; } = new DALLinkStatusMapper();

		public IDALMachineMapper DALMachineMapperMock { get; set; } = new DALMachineMapper();

		public IDALOrganizationMapper DALOrganizationMapperMock { get; set; } = new DALOrganizationMapper();

		public IDALTeamMapper DALTeamMapperMock { get; set; } = new DALTeamMapper();

		public IDALVersionInfoMapper DALVersionInfoMapperMock { get; set; } = new DALVersionInfoMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>075a2086bb03f597895a5b73e4814330</Hash>
</Codenesium>*/