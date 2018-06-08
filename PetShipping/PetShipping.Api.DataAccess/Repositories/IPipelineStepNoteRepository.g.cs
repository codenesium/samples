using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IPipelineStepNoteRepository
        {
                Task<PipelineStepNote> Create(PipelineStepNote item);

                Task Update(PipelineStepNote item);

                Task Delete(int id);

                Task<PipelineStepNote> Get(int id);

                Task<List<PipelineStepNote>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>9159e6872433764f41d0dfc42a067df4</Hash>
</Codenesium>*/