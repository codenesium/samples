using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IActionTemplateRepository
        {
                Task<ActionTemplate> Create(ActionTemplate item);

                Task Update(ActionTemplate item);

                Task Delete(string id);

                Task<ActionTemplate> Get(string id);

                Task<List<ActionTemplate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ActionTemplate> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>b1168839a80930207221493a11eacc18</Hash>
</Codenesium>*/