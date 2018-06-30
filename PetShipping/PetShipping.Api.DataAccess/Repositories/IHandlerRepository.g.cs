using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IHandlerRepository
        {
                Task<Handler> Create(Handler item);

                Task Update(Handler item);

                Task Delete(int id);

                Task<Handler> Get(int id);

                Task<List<Handler>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<AirTransport>> AirTransports(int handlerId, int limit = int.MaxValue, int offset = 0);

                Task<List<HandlerPipelineStep>> HandlerPipelineSteps(int handlerId, int limit = int.MaxValue, int offset = 0);

                Task<List<OtherTransport>> OtherTransports(int handlerId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7ef72322e8fd62b9c26871cd8788efda</Hash>
</Codenesium>*/