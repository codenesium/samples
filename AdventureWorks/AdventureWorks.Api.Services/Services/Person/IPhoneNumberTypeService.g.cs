using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IPhoneNumberTypeService
        {
                Task<CreateResponse<ApiPhoneNumberTypeResponseModel>> Create(
                        ApiPhoneNumberTypeRequestModel model);

                Task<ActionResponse> Update(int phoneNumberTypeID,
                                            ApiPhoneNumberTypeRequestModel model);

                Task<ActionResponse> Delete(int phoneNumberTypeID);

                Task<ApiPhoneNumberTypeResponseModel> Get(int phoneNumberTypeID);

                Task<List<ApiPhoneNumberTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>578209470e5823eed8a288c02c04d085</Hash>
</Codenesium>*/