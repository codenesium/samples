using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IBOLCommentsMapper
        {
                BOComments MapModelToBO(
                        int id,
                        ApiCommentsRequestModel model);

                ApiCommentsResponseModel MapBOToModel(
                        BOComments boComments);

                List<ApiCommentsResponseModel> MapBOToModel(
                        List<BOComments> items);
        }
}

/*<Codenesium>
    <Hash>06dcca819ec4e159f1be4c0a0ebad34e</Hash>
</Codenesium>*/