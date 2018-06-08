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

                Task<List<Illustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f48ab51468e2a8d04cf568d028fbe19a</Hash>
</Codenesium>*/