using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public abstract class BOLAbstractCommentsMapper
        {
                public virtual BOComments MapModelToBO(
                        int id,
                        ApiCommentsRequestModel model
                        )
                {
                        BOComments boComments = new BOComments();
                        boComments.SetProperties(
                                id,
                                model.CreationDate,
                                model.PostId,
                                model.Score,
                                model.Text,
                                model.UserId);
                        return boComments;
                }

                public virtual ApiCommentsResponseModel MapBOToModel(
                        BOComments boComments)
                {
                        var model = new ApiCommentsResponseModel();

                        model.SetProperties(boComments.CreationDate, boComments.Id, boComments.PostId, boComments.Score, boComments.Text, boComments.UserId);

                        return model;
                }

                public virtual List<ApiCommentsResponseModel> MapBOToModel(
                        List<BOComments> items)
                {
                        List<ApiCommentsResponseModel> response = new List<ApiCommentsResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>3804b4f503ed5c4486b0346a195e3fc0</Hash>
</Codenesium>*/