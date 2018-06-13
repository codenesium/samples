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

                Task<List<SpecialOffer>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<SpecialOfferProduct>> SpecialOfferProducts(int specialOfferID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>80d8f089ae083e9aa2db6140a3670533</Hash>
</Codenesium>*/