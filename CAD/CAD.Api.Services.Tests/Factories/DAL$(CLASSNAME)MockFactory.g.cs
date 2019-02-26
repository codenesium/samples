using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Moq;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALAddressMapper DALAddressMapperMock { get; set; } = new DALAddressMapper();

		public IDALCallMapper DALCallMapperMock { get; set; } = new DALCallMapper();

		public IDALCallDispositionMapper DALCallDispositionMapperMock { get; set; } = new DALCallDispositionMapper();

		public IDALCallPersonMapper DALCallPersonMapperMock { get; set; } = new DALCallPersonMapper();

		public IDALCallStatuMapper DALCallStatuMapperMock { get; set; } = new DALCallStatuMapper();

		public IDALCallTypeMapper DALCallTypeMapperMock { get; set; } = new DALCallTypeMapper();

		public IDALNoteMapper DALNoteMapperMock { get; set; } = new DALNoteMapper();

		public IDALOfficerMapper DALOfficerMapperMock { get; set; } = new DALOfficerMapper();

		public IDALOfficerCapabilitiesMapper DALOfficerCapabilitiesMapperMock { get; set; } = new DALOfficerCapabilitiesMapper();

		public IDALPersonMapper DALPersonMapperMock { get; set; } = new DALPersonMapper();

		public IDALPersonTypeMapper DALPersonTypeMapperMock { get; set; } = new DALPersonTypeMapper();

		public IDALUnitMapper DALUnitMapperMock { get; set; } = new DALUnitMapper();

		public IDALUnitDispositionMapper DALUnitDispositionMapperMock { get; set; } = new DALUnitDispositionMapper();

		public IDALVehicleMapper DALVehicleMapperMock { get; set; } = new DALVehicleMapper();

		public IDALVehicleCapabilitiesMapper DALVehicleCapabilitiesMapperMock { get; set; } = new DALVehicleCapabilitiesMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8894970f225868b4ee9923b4be1be96d</Hash>
</Codenesium>*/