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
    <Hash>b0402f340e32dd0d9417b743c283683c</Hash>
</Codenesium>*/