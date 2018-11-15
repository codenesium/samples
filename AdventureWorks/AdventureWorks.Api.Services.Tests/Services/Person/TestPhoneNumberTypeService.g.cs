using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PhoneNumberType")]
	[Trait("Area", "Services")]
	public partial class PhoneNumberTypeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
			var records = new List<PhoneNumberType>();
			records.Add(new PhoneNumberType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock);

			List<ApiPhoneNumberTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
			var record = new PhoneNumberType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock);

			ApiPhoneNumberTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PhoneNumberType>(null));
			var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock);

			ApiPhoneNumberTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
			var model = new ApiPhoneNumberTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PhoneNumberType>())).Returns(Task.FromResult(new PhoneNumberType()));
			var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock);

			CreateResponse<ApiPhoneNumberTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPhoneNumberTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PhoneNumberType>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
			var model = new ApiPhoneNumberTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PhoneNumberType>())).Returns(Task.FromResult(new PhoneNumberType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PhoneNumberType()));
			var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock);

			UpdateResponse<ApiPhoneNumberTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PhoneNumberType>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
			var model = new ApiPhoneNumberTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c12b36455551b9fcd696b7bc2d9e78a0</Hash>
</Codenesium>*/