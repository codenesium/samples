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
    <Hash>8e5481e1a5835a4c5c3cedf5d4f1f95e</Hash>
</Codenesium>*/