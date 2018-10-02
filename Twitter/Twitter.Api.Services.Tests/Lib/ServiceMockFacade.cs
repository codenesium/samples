using Microsoft.Extensions.Logging;
using Moq;

namespace TwitterNS.Api.Services.Tests
{
      public class ServiceMockFacade<T> : AbstractServiceMockFacade<T>
        where T : class
    {
    }
}