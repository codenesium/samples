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

                Task<List<SpecialOffer>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<SpecialOfferProduct>> SpecialOfferProducts(int specialOfferID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>463da2a1c89748f7e367820316dc04fa</Hash>
</Codenesium>*/