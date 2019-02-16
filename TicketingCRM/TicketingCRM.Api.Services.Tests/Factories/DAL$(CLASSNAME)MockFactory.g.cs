using Moq;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALAdminMapper DALAdminMapperMock { get; set; } = new DALAdminMapper();

		public IDALCityMapper DALCityMapperMock { get; set; } = new DALCityMapper();

		public IDALCountryMapper DALCountryMapperMock { get; set; } = new DALCountryMapper();

		public IDALCustomerMapper DALCustomerMapperMock { get; set; } = new DALCustomerMapper();

		public IDALEventMapper DALEventMapperMock { get; set; } = new DALEventMapper();

		public IDALProvinceMapper DALProvinceMapperMock { get; set; } = new DALProvinceMapper();

		public IDALSaleMapper DALSaleMapperMock { get; set; } = new DALSaleMapper();

		public IDALSaleTicketMapper DALSaleTicketMapperMock { get; set; } = new DALSaleTicketMapper();

		public IDALTicketMapper DALTicketMapperMock { get; set; } = new DALTicketMapper();

		public IDALTicketStatuMapper DALTicketStatuMapperMock { get; set; } = new DALTicketStatuMapper();

		public IDALTransactionMapper DALTransactionMapperMock { get; set; } = new DALTransactionMapper();

		public IDALTransactionStatuMapper DALTransactionStatuMapperMock { get; set; } = new DALTransactionStatuMapper();

		public IDALVenueMapper DALVenueMapperMock { get; set; } = new DALVenueMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e73ddca8c9a7c09a3904e96c06fb2d82</Hash>
</Codenesium>*/