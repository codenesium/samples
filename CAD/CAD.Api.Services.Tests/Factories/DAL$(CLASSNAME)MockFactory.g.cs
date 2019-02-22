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

		public IDALCallStatuMapper DALCallStatuMapperMock { get; set; } = new DALCallStatuMapper();

		public IDALCallTypeMapper DALCallTypeMapperMock { get; set; } = new DALCallTypeMapper();

		public IDALNoteMapper DALNoteMapperMock { get; set; } = new DALNoteMapper();

		public IDALOfficerMapper DALOfficerMapperMock { get; set; } = new DALOfficerMapper();

		public IDALOfficerCapabilityMapper DALOfficerCapabilityMapperMock { get; set; } = new DALOfficerCapabilityMapper();

		public IDALOfficerRefCapabilityMapper DALOfficerRefCapabilityMapperMock { get; set; } = new DALOfficerRefCapabilityMapper();

		public IDALPersonMapper DALPersonMapperMock { get; set; } = new DALPersonMapper();

		public IDALPersonTypeMapper DALPersonTypeMapperMock { get; set; } = new DALPersonTypeMapper();

		public IDALUnitMapper DALUnitMapperMock { get; set; } = new DALUnitMapper();

		public IDALUnitDispositionMapper DALUnitDispositionMapperMock { get; set; } = new DALUnitDispositionMapper();

		public IDALUnitOfficerMapper DALUnitOfficerMapperMock { get; set; } = new DALUnitOfficerMapper();

		public IDALVehicleMapper DALVehicleMapperMock { get; set; } = new DALVehicleMapper();

		public IDALVehicleCapabilityMapper DALVehicleCapabilityMapperMock { get; set; } = new DALVehicleCapabilityMapper();

		public IDALVehicleOfficerMapper DALVehicleOfficerMapperMock { get; set; } = new DALVehicleOfficerMapper();

		public IDALVehicleRefCapabilityMapper DALVehicleRefCapabilityMapperMock { get; set; } = new DALVehicleRefCapabilityMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>898ac167b023c5b1a27ac596e3a7be62</Hash>
</Codenesium>*/