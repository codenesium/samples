using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALChainMapper DALChainMapperMock { get; set; } = new DALChainMapper();

		public IDALChainStatusMapper DALChainStatusMapperMock { get; set; } = new DALChainStatusMapper();

		public IDALClaspMapper DALClaspMapperMock { get; set; } = new DALClaspMapper();

		public IDALLinkMapper DALLinkMapperMock { get; set; } = new DALLinkMapper();

		public IDALLinkLogMapper DALLinkLogMapperMock { get; set; } = new DALLinkLogMapper();

		public IDALLinkStatusMapper DALLinkStatusMapperMock { get; set; } = new DALLinkStatusMapper();

		public IDALMachineMapper DALMachineMapperMock { get; set; } = new DALMachineMapper();

		public IDALMachineRefTeamMapper DALMachineRefTeamMapperMock { get; set; } = new DALMachineRefTeamMapper();

		public IDALOrganizationMapper DALOrganizationMapperMock { get; set; } = new DALOrganizationMapper();

		public IDALTeamMapper DALTeamMapperMock { get; set; } = new DALTeamMapper();

		public IDALVersionInfoMapper DALVersionInfoMapperMock { get; set; } = new DALVersionInfoMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>10fa8e07ffd2c6d828157c5aae4dd691</Hash>
</Codenesium>*/