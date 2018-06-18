using Microsoft.Extensions.Logging;
using Moq;

namespace OctopusDeployNS.Api.Services.Tests
{
    public abstract class AbstractServiceMockFacade<T>
        where T : class
    {
        public Mock<ILogger<T>> LoggerMock { get; set; } = new Mock<ILogger<T>>();

        public Mock<T> RepositoryMock { get; set; } = new Mock<T>();

        public BOLMapperMockFactory BOLMapperMockFactory { get; private set; } = new BOLMapperMockFactory();

        public DALMapperMockFactory DALMapperMockFactory { get; private set; } = new DALMapperMockFactory();

        public ModelValidatorMockFactory ModelValidatorMockFactory { get; private set; } = new ModelValidatorMockFactory();
    }
}