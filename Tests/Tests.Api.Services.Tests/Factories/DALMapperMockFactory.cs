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

		public IDALCompositePrimaryKeyMapper DALCompositePrimaryKeyMapperMock { get; set; } = new DALCompositePrimaryKeyMapper();

		public IDALIncludedColumnTestMapper DALIncludedColumnTestMapperMock { get; set; } = new DALIncludedColumnTestMapper();

		public IDALPersonMapper DALPersonMapperMock { get; set; } = new DALPersonMapper();

		public IDALRowVersionCheckMapper DALRowVersionCheckMapperMock { get; set; } = new DALRowVersionCheckMapper();

		public IDALSelfReferenceMapper DALSelfReferenceMapperMock { get; set; } = new DALSelfReferenceMapper();

		public IDALTableMapper DALTableMapperMock { get; set; } = new DALTableMapper();

		public IDALTestAllFieldTypeMapper DALTestAllFieldTypeMapperMock { get; set; } = new DALTestAllFieldTypeMapper();

		public IDALTestAllFieldTypesNullableMapper DALTestAllFieldTypesNullableMapperMock { get; set; } = new DALTestAllFieldTypesNullableMapper();

		public IDALTimestampCheckMapper DALTimestampCheckMapperMock { get; set; } = new DALTimestampCheckMapper();

		public IDALVPersonMapper DALVPersonMapperMock { get; set; } = new DALVPersonMapper();

		public IDALSchemaAPersonMapper DALSchemaAPersonMapperMock { get; set; } = new DALSchemaAPersonMapper();

		public IDALSchemaBPersonMapper DALSchemaBPersonMapperMock { get; set; } = new DALSchemaBPersonMapper();

		public IDALPersonRefMapper DALPersonRefMapperMock { get; set; } = new DALPersonRefMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>72a0582f8a5a6d8ab91f1268d0c60169</Hash>
</Codenesium>*/