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

                Task<List<ApiPhoneNumberTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPersonPhoneResponseModel>> PersonPhones(int phoneNumberTypeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>8c303ed0fe58a774fbb974a40345c232</Hash>
</Codenesium>*/