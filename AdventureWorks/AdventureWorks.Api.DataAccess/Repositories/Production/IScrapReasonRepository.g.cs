using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IScrapReasonRepository
        {
                Task<ScrapReason> Create(ScrapReason item);

                Task Update(ScrapReason item);

                Task Delete(short scrapReasonID);

                Task<ScrapReason> Get(short scrapReasonID);

                Task<List<ScrapReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ScrapReason> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>587d583ff208c665132cd04f9df6243b</Hash>
</Codenesium>*/