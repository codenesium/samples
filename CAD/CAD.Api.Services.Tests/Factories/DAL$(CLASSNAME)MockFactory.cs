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

		public IDALCallAssignmentMapper DALCallAssignmentMapperMock { get; set; } = new DALCallAssignmentMapper();

		public IDALCallDispositionMapper DALCallDispositionMapperMock { get; set; } = new DALCallDispositionMapper();

		public IDALCallPersonMapper DALCallPersonMapperMock { get; set; } = new DALCallPersonMapper();

		public IDALCallStatusMapper DALCallStatusMapperMock { get; set; } = new DALCallStatusMapper();

		public IDALCallTypeMapper DALCallTypeMapperMock { get; set; } = new DALCallTypeMapper();

		public IDALNoteMapper DALNoteMapperMock { get; set; } = new DALNoteMapper();

		public IDALOffCapabilityMapper DALOffCapabilityMapperMock { get; set; } = new DALOffCapabilityMapper();

		public IDALOfficerMapper DALOfficerMapperMock { get; set; } = new DALOfficerMapper();

		public IDALOfficerCapabilitiesMapper DALOfficerCapabilitiesMapperMock { get; set; } = new DALOfficerCapabilitiesMapper();

		public IDALPersonMapper DALPersonMapperMock { get; set; } = new DALPersonMapper();

		public IDALPersonTypeMapper DALPersonTypeMapperMock { get; set; } = new DALPersonTypeMapper();

		public IDALUnitMapper DALUnitMapperMock { get; set; } = new DALUnitMapper();

		public IDALUnitDispositionMapper DALUnitDispositionMapperMock { get; set; } = new DALUnitDispositionMapper();

		public IDALUnitOfficerMapper DALUnitOfficerMapperMock { get; set; } = new DALUnitOfficerMapper();

		public IDALVehCapabilityMapper DALVehCapabilityMapperMock { get; set; } = new DALVehCapabilityMapper();

		public IDALVehicleMapper DALVehicleMapperMock { get; set; } = new DALVehicleMapper();

		public IDALVehicleCapabilitiesMapper DALVehicleCapabilitiesMapperMock { get; set; } = new DALVehicleCapabilitiesMapper();

		public IDALVehicleOfficerMapper DALVehicleOfficerMapperMock { get; set; } = new DALVehicleOfficerMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8d6f9f9b04d7790a461fa7604be81364</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/