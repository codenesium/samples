using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
        public interface ITestAllFieldTypesNullableRepository
        {
                Task<TestAllFieldTypesNullable> Create(TestAllFieldTypesNullable item);

                Task Update(TestAllFieldTypesNullable item);

                Task Delete(int id);

                Task<TestAllFieldTypesNullable> Get(int id);

                Task<List<TestAllFieldTypesNullable>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6275a06fd6f779ca84dd5f470b8956d7</Hash>
</Codenesium>*/