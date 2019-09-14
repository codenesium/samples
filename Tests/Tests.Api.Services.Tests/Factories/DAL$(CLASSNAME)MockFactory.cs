using Moq;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALColumnSameAsFKTableMapper DALColumnSameAsFKTableMapperMock { get; set; } = new DALColumnSameAsFKTableMapper();

		public IDALIncludedColumnTestMapper DALIncludedColumnTestMapperMock { get; set; } = new DALIncludedColumnTestMapper();

		public IDALPersonMapper DALPersonMapperMock { get; set; } = new DALPersonMapper();

		public IDALRowVersionCheckMapper DALRowVersionCheckMapperMock { get; set; } = new DALRowVersionCheckMapper();

		public IDALSelfReferenceMapper DALSelfReferenceMapperMock { get; set; } = new DALSelfReferenceMapper();

		public IDALTableMapper DALTableMapperMock { get; set; } = new DALTableMapper();

		public IDALTestAllFieldTypeMapper DALTestAllFieldTypeMapperMock { get; set; } = new DALTestAllFieldTypeMapper();

		public IDALTestAllFieldTypesNullableMapper DALTestAllFieldTypesNullableMapperMock { get; set; } = new DALTestAllFieldTypesNullableMapper();

		public IDALTimestampCheckMapper DALTimestampCheckMapperMock { get; set; } = new DALTimestampCheckMapper();

		public IDALVPersonMapper DALVPersonMapperMock { get; set; } = new DALVPersonMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1088b501e0f509d91d3fec2fae9229fd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/