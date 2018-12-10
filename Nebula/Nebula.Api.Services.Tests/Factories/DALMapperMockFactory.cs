using Moq;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
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
    <Hash>59d4157153e2dc4a3884d7f4009cd739</Hash>
</Codenesium>*/