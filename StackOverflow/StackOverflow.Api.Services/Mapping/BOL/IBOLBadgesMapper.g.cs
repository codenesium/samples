using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IBOLBadgesMapper
        {
                BOBadges MapModelToBO(
                        int id,
                        ApiBadgesRequestModel model);

                ApiBadgesResponseModel MapBOToModel(
                        BOBadges boBadges);

                List<ApiBadgesResponseModel> MapBOToModel(
                        List<BOBadges> items);
        }
}

/*<Codenesium>
    <Hash>2948bc42208740c328fed188a3966277</Hash>
</Codenesium>*/