using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBusinessEntityContactService
        {
                Task<CreateResponse<ApiBusinessEntityContactResponseModel>> Create(
                        ApiBusinessEntityContactRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiBusinessEntityContactRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiBusinessEntityContactResponseModel> Get(int businessEntityID);

                Task<List<ApiBusinessEntityContactResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiBusinessEntityContactResponseModel>> ByContactTypeID(int contactTypeID);
                Task<List<ApiBusinessEntityContactResponseModel>> ByPersonID(int personID);
        }
}

/*<Codenesium>
    <Hash>33ea069f6d0ee220da068efc76483510</Hash>
</Codenesium>*/