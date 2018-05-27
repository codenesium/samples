using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferRepository
	{
		Task<DTOSpecialOffer> Create(DTOSpecialOffer dto);

		Task Update(int specialOfferID,
		            DTOSpecialOffer dto);

		Task Delete(int specialOfferID);

		Task<DTOSpecialOffer> Get(int specialOfferID);

		Task<List<DTOSpecialOffer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b111527006ab49e6772fc7bb51c6cf24</Hash>
</Codenesium>*/