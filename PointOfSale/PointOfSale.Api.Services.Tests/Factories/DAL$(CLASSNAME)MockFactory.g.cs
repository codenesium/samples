using Moq;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PointOfSaleNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALCustomerMapper DALCustomerMapperMock { get; set; } = new DALCustomerMapper();

		public IDALProductMapper DALProductMapperMock { get; set; } = new DALProductMapper();

		public IDALSaleMapper DALSaleMapperMock { get; set; } = new DALSaleMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>3f3e37c999591e3ed51805ab316e2e87</Hash>
</Codenesium>*/