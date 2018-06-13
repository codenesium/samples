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

                Task<List<PipelineStepNote>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>9f5f2044491cfa0fe3df097dcecd7adf</Hash>
</Codenesium>*/