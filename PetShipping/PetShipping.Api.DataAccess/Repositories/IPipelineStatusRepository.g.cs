using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IPipelineStatusRepository
        {
                Task<PipelineStatus> Create(PipelineStatus item);

                Task Update(PipelineStatus item);

                Task Delete(int id);

                Task<PipelineStatus> Get(int id);

                Task<List<PipelineStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>8b695a47c723421790a9db0278944ff7</Hash>
</Codenesium>*/