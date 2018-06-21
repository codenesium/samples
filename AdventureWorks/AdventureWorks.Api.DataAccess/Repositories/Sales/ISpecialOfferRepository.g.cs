using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>9938ba2e1b33105d0b520c44c3634e0c</Hash>
</Codenesium>*/