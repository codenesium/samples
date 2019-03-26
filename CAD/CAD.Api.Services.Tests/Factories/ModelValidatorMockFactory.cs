using CADNS.Api.Contracts;
using CADNS.Api.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiAddressServerRequestModelValidator> AddressModelValidatorMock { get; set; } = new Mock<IApiAddressServerRequestModelValidator>();

		public Mock<IApiCallServerRequestModelValidator> CallModelValidatorMock { get; set; } = new Mock<IApiCallServerRequestModelValidator>();

		public Mock<IApiCallDispositionServerRequestModelValidator> CallDispositionModelValidatorMock { get; set; } = new Mock<IApiCallDispositionServerRequestModelValidator>();

		public Mock<IApiCallPersonServerRequestModelValidator> CallPersonModelValidatorMock { get; set; } = new Mock<IApiCallPersonServerRequestModelValidator>();

		public Mock<IApiCallStatuServerRequestModelValidator> CallStatuModelValidatorMock { get; set; } = new Mock<IApiCallStatuServerRequestModelValidator>();

		public Mock<IApiCallTypeServerRequestModelValidator> CallTypeModelValidatorMock { get; set; } = new Mock<IApiCallTypeServerRequestModelValidator>();

		public Mock<IApiNoteServerRequestModelValidator> NoteModelValidatorMock { get; set; } = new Mock<IApiNoteServerRequestModelValidator>();

		public Mock<IApiOfficerServerRequestModelValidator> OfficerModelValidatorMock { get; set; } = new Mock<IApiOfficerServerRequestModelValidator>();

		public Mock<IApiOfficerCapabilityServerRequestModelValidator> OfficerCapabilityModelValidatorMock { get; set; } = new Mock<IApiOfficerCapabilityServerRequestModelValidator>();

		public Mock<IApiPersonServerRequestModelValidator> PersonModelValidatorMock { get; set; } = new Mock<IApiPersonServerRequestModelValidator>();

		public Mock<IApiPersonTypeServerRequestModelValidator> PersonTypeModelValidatorMock { get; set; } = new Mock<IApiPersonTypeServerRequestModelValidator>();

		public Mock<IApiUnitServerRequestModelValidator> UnitModelValidatorMock { get; set; } = new Mock<IApiUnitServerRequestModelValidator>();

		public Mock<IApiUnitDispositionServerRequestModelValidator> UnitDispositionModelValidatorMock { get; set; } = new Mock<IApiUnitDispositionServerRequestModelValidator>();

		public Mock<IApiVehicleServerRequestModelValidator> VehicleModelValidatorMock { get; set; } = new Mock<IApiVehicleServerRequestModelValidator>();

		public Mock<IApiVehicleCapabilittyServerRequestModelValidator> VehicleCapabilittyModelValidatorMock { get; set; } = new Mock<IApiVehicleCapabilittyServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.AddressModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAddressServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AddressModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAddressServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AddressModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CallModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCallServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CallModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CallModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CallDispositionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCallDispositionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CallDispositionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallDispositionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CallDispositionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CallPersonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCallPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CallPersonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CallPersonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CallStatuModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCallStatuServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CallStatuModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallStatuServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CallStatuModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CallTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCallTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CallTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CallTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.NoteModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiNoteServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.NoteModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiNoteServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.NoteModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.OfficerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OfficerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OfficerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.OfficerCapabilityModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerCapabilityServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OfficerCapabilityModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilityServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OfficerCapabilityModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PersonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PersonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PersonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PersonTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPersonTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PersonTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PersonTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UnitModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUnitServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UnitModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUnitServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UnitModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UnitDispositionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUnitDispositionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UnitDispositionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUnitDispositionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UnitDispositionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VehicleModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VehicleModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VehicleModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VehicleCapabilittyModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleCapabilittyServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VehicleCapabilittyModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilittyServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VehicleCapabilittyModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>c76b10f68a303e53bd1b6b98208840bd</Hash>
</Codenesium>*/