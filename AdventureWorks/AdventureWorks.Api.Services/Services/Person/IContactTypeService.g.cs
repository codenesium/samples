using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IContactTypeService
        {
                Task<CreateResponse<ApiContactTypeResponseModel>> Create(
                        ApiContactTypeRequestModel model);

                Task<ActionResponse> Update(int contactTypeID,
                                            ApiContactTypeRequestModel model);

                Task<ActionResponse> Delete(int contactTypeID);

                Task<ApiContactTypeResponseModel> Get(int contactTypeID);

                Task<List<ApiContactTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiContactTypeResponseModel> ByName(string name);

                Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int contactTypeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>cff79e648038252a82771b875e073626</Hash>
</Codenesium>*/