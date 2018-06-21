using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IIllustrationRepository
        {
                Task<Illustration> Create(Illustration item);

                Task Update(Illustration item);

                Task Delete(int illustrationID);

                Task<Illustration> Get(int illustrationID);

                Task<List<Illustration>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ProductModelIllustration>> ProductModelIllustrations(int illustrationID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7b38e7731ef1b9e0fceb12feb09971b7</Hash>
</Codenesium>*/