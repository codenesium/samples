using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IIllustrationRepository
        {
                Task<Illustration> Create(Illustration item);

                Task Update(Illustration item);

                Task Delete(int illustrationID);

                Task<Illustration> Get(int illustrationID);

                Task<List<Illustration>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<ProductModelIllustration>> ProductModelIllustrations(int illustrationID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d3bb99efd5ad29730e8f2399613b4d99</Hash>
</Codenesium>*/