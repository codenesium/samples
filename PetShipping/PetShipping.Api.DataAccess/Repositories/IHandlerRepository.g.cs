using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IHandlerRepository
        {
                Task<Handler> Create(Handler item);

                Task Update(Handler item);

                Task Delete(int id);

                Task<Handler> Get(int id);

                Task<List<Handler>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<AirTransport>> AirTransports(int handlerId, int limit = int.MaxValue, int offset = 0);
                Task<List<HandlerPipelineStep>> HandlerPipelineSteps(int handlerId, int limit = int.MaxValue, int offset = 0);
                Task<List<OtherTransport>> OtherTransports(int handlerId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>0a318bc011d08994dad34020faf29498</Hash>
</Codenesium>*/