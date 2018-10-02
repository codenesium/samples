using Moq;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLColumnSameAsFKTableMapper BOLColumnSameAsFKTableMapperMock { get; set; } = new BOLColumnSameAsFKTableMapper();

		public IBOLCompositePrimaryKeyMapper BOLCompositePrimaryKeyMapperMock { get; set; } = new BOLCompositePrimaryKeyMapper();

		public IBOLIncludedColumnTestMapper BOLIncludedColumnTestMapperMock { get; set; } = new BOLIncludedColumnTestMapper();

		public IBOLPersonMapper BOLPersonMapperMock { get; set; } = new BOLPersonMapper();

		public IBOLRowVersionCheckMapper BOLRowVersionCheckMapperMock { get; set; } = new BOLRowVersionCheckMapper();

		public IBOLSelfReferenceMapper BOLSelfReferenceMapperMock { get; set; } = new BOLSelfReferenceMapper();

		public IBOLTableMapper BOLTableMapperMock { get; set; } = new BOLTableMapper();

		public IBOLTestAllFieldTypeMapper BOLTestAllFieldTypeMapperMock { get; set; } = new BOLTestAllFieldTypeMapper();

		public IBOLTestAllFieldTypesNullableMapper BOLTestAllFieldTypesNullableMapperMock { get; set; } = new BOLTestAllFieldTypesNullableMapper();

		public IBOLTimestampCheckMapper BOLTimestampCheckMapperMock { get; set; } = new BOLTimestampCheckMapper();

		public IBOLVPersonMapper BOLVPersonMapperMock { get; set; } = new BOLVPersonMapper();

		public IBOLSchemaAPersonMapper BOLSchemaAPersonMapperMock { get; set; } = new BOLSchemaAPersonMapper();

		public IBOLSchemaBPersonMapper BOLSchemaBPersonMapperMock { get; set; } = new BOLSchemaBPersonMapper();

		public IBOLPersonRefMapper BOLPersonRefMapperMock { get; set; } = new BOLPersonRefMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>0e51efcbccafa315aa7e99325945d873</Hash>
</Codenesium>*/