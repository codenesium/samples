using Moq;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLAdminMapper BOLAdminMapperMock { get; set; } = new BOLAdminMapper();

		public IBOLCityMapper BOLCityMapperMock { get; set; } = new BOLCityMapper();

		public IBOLCountryMapper BOLCountryMapperMock { get; set; } = new BOLCountryMapper();

		public IBOLCustomerMapper BOLCustomerMapperMock { get; set; } = new BOLCustomerMapper();

		public IBOLEventMapper BOLEventMapperMock { get; set; } = new BOLEventMapper();

		public IBOLProvinceMapper BOLProvinceMapperMock { get; set; } = new BOLProvinceMapper();

		public IBOLSaleMapper BOLSaleMapperMock { get; set; } = new BOLSaleMapper();

		public IBOLSaleTicketsMapper BOLSaleTicketsMapperMock { get; set; } = new BOLSaleTicketsMapper();

		public IBOLTicketMapper BOLTicketMapperMock { get; set; } = new BOLTicketMapper();

		public IBOLTicketStatusMapper BOLTicketStatusMapperMock { get; set; } = new BOLTicketStatusMapper();

		public IBOLTransactionMapper BOLTransactionMapperMock { get; set; } = new BOLTransactionMapper();

		public IBOLTransactionStatusMapper BOLTransactionStatusMapperMock { get; set; } = new BOLTransactionStatusMapper();

		public IBOLVenueMapper BOLVenueMapperMock { get; set; } = new BOLVenueMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a1ca87ea067adab3b98a5b86358c93e3</Hash>
</Codenesium>*/