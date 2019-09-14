using MediatR;
using Microsoft.Extensions.Logging;
using Moq;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
    public class ServiceMockFacade<S, R>
        where S : class // service type
		where R : class // repository type
    {
        public Mock<ILogger<S>> LoggerMock { get; set; } = new Mock<ILogger<S>>();

		public Mock<IMediator> MediatorMock { get; set; } = new Mock<IMediator>();

        public Mock<R> RepositoryMock { get; set; } = new Mock<R>();

        public DALMapperMockFactory DALMapperMockFactory { get; private set; } = new DALMapperMockFactory();

        public ModelValidatorMockFactory ModelValidatorMockFactory { get; private set; } = new ModelValidatorMockFactory();
    }
}