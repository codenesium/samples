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

		public IDALOrganizationMapper DALOrganizationMapperMock { get; set; } = new DALOrganizationMapper();

		public IDALTeamMapper DALTeamMapperMock { get; set; } = new DALTeamMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>aa766e481590c1a35b2a59593885157b</Hash>
</Codenesium>*/