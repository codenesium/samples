using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IAirTransportRepository
	{
		Task<AirTransport> Create(AirTransport item);

		Task Update(AirTransport item);

		Task Delete(int id);

		Task<AirTransport> Get(int id);

		Task<List<AirTransport>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Handler> HandlerByHandlerId(int handlerId);
	}
}

/*<Codenesium>
    <Hash>226f4d23b61b7e48f45bd04c40652e7b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/