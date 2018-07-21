using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
        public interface ITestAllFieldTypeRepository
        {
                Task<TestAllFieldType> Create(TestAllFieldType item);

                Task Update(TestAllFieldType item);

                Task Delete(int id);

                Task<TestAllFieldType> Get(int id);

                Task<List<TestAllFieldType>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d65bad8783038bfa629cd25a3503e383</Hash>
</Codenesium>*/