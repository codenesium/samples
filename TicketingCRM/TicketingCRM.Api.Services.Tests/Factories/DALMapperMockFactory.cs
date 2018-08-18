using Moq;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;

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

		public IDALSaleTicketsMapper DALSaleTicketsMapperMock { get; set; } = new DALSaleTicketsMapper();

		public IDALTicketMapper DALTicketMapperMock { get; set; } = new DALTicketMapper();

		public IDALTicketStatusMapper DALTicketStatusMapperMock { get; set; } = new DALTicketStatusMapper();

		public IDALTransactionMapper DALTransactionMapperMock { get; set; } = new DALTransactionMapper();

		public IDALTransactionStatusMapper DALTransactionStatusMapperMock { get; set; } = new DALTransactionStatusMapper();

		public IDALVenueMapper DALVenueMapperMock { get; set; } = new DALVenueMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>ba8e6304ac0a87aab9ff8547f2391c9c</Hash>
</Codenesium>*/