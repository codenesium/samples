using Moq;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;

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
    <Hash>884cb9bb1265af5bda1303c549600c21</Hash>
</Codenesium>*/