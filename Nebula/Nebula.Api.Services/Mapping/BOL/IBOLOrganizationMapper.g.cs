using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface IBOLOrganizationMapper
        {
                BOOrganization MapModelToBO(
                        int id,
                        ApiOrganizationRequestModel model);

                ApiOrganizationResponseModel MapBOToModel(
                        BOOrganization boOrganization);

                List<ApiOrganizationResponseModel> MapBOToModel(
                        List<BOOrganization> items);
        }
}

/*<Codenesium>
    <Hash>837b09100734e8e9d816f6fac3c5a52f</Hash>
</Codenesium>*/