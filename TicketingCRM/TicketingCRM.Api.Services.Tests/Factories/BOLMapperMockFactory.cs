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

		public IBOLSaleTicketMapper BOLSaleTicketMapperMock { get; set; } = new BOLSaleTicketMapper();

		public IBOLTicketMapper BOLTicketMapperMock { get; set; } = new BOLTicketMapper();

		public IBOLTicketStatuMapper BOLTicketStatuMapperMock { get; set; } = new BOLTicketStatuMapper();

		public IBOLTransactionMapper BOLTransactionMapperMock { get; set; } = new BOLTransactionMapper();

		public IBOLTransactionStatuMapper BOLTransactionStatuMapperMock { get; set; } = new BOLTransactionStatuMapper();

		public IBOLVenueMapper BOLVenueMapperMock { get; set; } = new BOLVenueMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>852f445ddb14135f41ad71c3b823bb00</Hash>
</Codenesium>*/