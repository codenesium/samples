using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISpecialOfferProductRepository
        {
                Task<SpecialOfferProduct> Create(SpecialOfferProduct item);

                Task Update(SpecialOfferProduct item);

                Task Delete(int specialOfferID);

                Task<SpecialOfferProduct> Get(int specialOfferID);

                Task<List<SpecialOfferProduct>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<SpecialOfferProduct>> ByProductID(int productID);

                Task<List<SalesOrderDetail>> SalesOrderDetails(int specialOfferID, int limit = int.MaxValue, int offset = 0);

                Task<SpecialOffer> GetSpecialOffer(int specialOfferID);
        }
}

/*<Codenesium>
    <Hash>e217e3539d9a25f2be6fd2bc353c0799</Hash>
</Codenesium>*/