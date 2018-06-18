using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ClientCommunication")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiClientCommunicationRequestModelValidatorTest
        {
                public ApiClientCommunicationRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ClientId_Create_Valid_Reference()
                {
                        Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
                        clientCommunicationRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(new Client()));

                        var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

                        await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ClientId, 1);
                }

                [Fact]
                public async void ClientId_Create_Invalid_Reference()
                {
                        Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
                        clientCommunicationRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(null));

                        var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

                        await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ClientId, 1);
                }

                [Fact]
                public async void ClientId_Update_Valid_Reference()
                {
                        Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
                        clientCommunicationRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(new Client()));

                        var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiClientCommunicationRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ClientId, 1);
                }

                [Fact]
                public async void ClientId_Update_Invalid_Reference()
                {
                        Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
                        clientCommunicationRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(null));

                        var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiClientCommunicationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ClientId, 1);
                }

                [Fact]
                public async void EmployeeId_Create_Valid_Reference()
                {
                        Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
                        clientCommunicationRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

                        var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

                        await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeId, 1);
                }

                [Fact]
                public async void EmployeeId_Create_Invalid_Reference()
                {
                        Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
                        clientCommunicationRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

                        var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

                        await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EmployeeId, 1);
                }

                [Fact]
                public async void EmployeeId_Update_Valid_Reference()
                {
                        Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
                        clientCommunicationRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

                        var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiClientCommunicationRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeId, 1);
                }

                [Fact]
                public async void EmployeeId_Update_Invalid_Reference()
                {
                        Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
                        clientCommunicationRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

                        var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiClientCommunicationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EmployeeId, 1);
                }

                [Fact]
                public async void Notes_Create_null()
                {
                        Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
                        clientCommunicationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ClientCommunication()));

                        var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

                        await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Notes, null as string);
                }

                [Fact]
                public async void Notes_Update_null()
                {
                        Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
                        clientCommunicationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ClientCommunication()));

                        var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiClientCommunicationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Notes, null as string);
                }
        }
}

/*<Codenesium>
    <Hash>e6682a42bb0c05b740e9b131f8acb0f2</Hash>
</Codenesium>*/