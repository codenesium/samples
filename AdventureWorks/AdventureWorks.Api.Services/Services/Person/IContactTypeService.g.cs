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

                Task<List<ApiContactTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiContactTypeResponseModel> GetName(string name);

                Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int contactTypeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>df9d4bec11f54461bd5b1aa926cf8f42</Hash>
</Codenesium>*/