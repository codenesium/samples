using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISpecialOfferRepository
        {
                Task<SpecialOffer> Create(SpecialOffer item);

                Task Update(SpecialOffer item);

                Task Delete(int specialOfferID);

                Task<SpecialOffer> Get(int specialOfferID);

                Task<List<SpecialOffer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>cd79451c585b76a89530c777d594ad83</Hash>
</Codenesium>*/