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

		public IDALChainStatuMapper DALChainStatuMapperMock { get; set; } = new DALChainStatuMapper();

		public IDALClaspMapper DALClaspMapperMock { get; set; } = new DALClaspMapper();

		public IDALLinkMapper DALLinkMapperMock { get; set; } = new DALLinkMapper();

		public IDALLinkLogMapper DALLinkLogMapperMock { get; set; } = new DALLinkLogMapper();

		public IDALLinkStatuMapper DALLinkStatuMapperMock { get; set; } = new DALLinkStatuMapper();

		public IDALMachineMapper DALMachineMapperMock { get; set; } = new DALMachineMapper();

		public IDALMachineRefTeamMapper DALMachineRefTeamMapperMock { get; set; } = new DALMachineRefTeamMapper();

		public IDALOrganizationMapper DALOrganizationMapperMock { get; set; } = new DALOrganizationMapper();

		public IDALSysdiagramMapper DALSysdiagramMapperMock { get; set; } = new DALSysdiagramMapper();

		public IDALTeamMapper DALTeamMapperMock { get; set; } = new DALTeamMapper();

		public IDALVersionInfoMapper DALVersionInfoMapperMock { get; set; } = new DALVersionInfoMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e4f046ce0e4a8e135a8295434a45954e</Hash>
</Codenesium>*/