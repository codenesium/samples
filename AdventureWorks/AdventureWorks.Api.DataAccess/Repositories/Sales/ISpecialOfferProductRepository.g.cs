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

                Task<List<SpecialOfferProduct>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<SpecialOfferProduct>> GetProductID(int productID);

                Task<List<SalesOrderDetail>> SalesOrderDetails(int specialOfferID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f513be5d2b6ff8972e85da363b8ebfe9</Hash>
</Codenesium>*/