using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public abstract class BOLAbstractBadgesMapper
        {
                public virtual BOBadges MapModelToBO(
                        int id,
                        ApiBadgesRequestModel model
                        )
                {
                        BOBadges boBadges = new BOBadges();
                        boBadges.SetProperties(
                                id,
                                model.Date,
                                model.Name,
                                model.UserId);
                        return boBadges;
                }

                public virtual ApiBadgesResponseModel MapBOToModel(
                        BOBadges boBadges)
                {
                        var model = new ApiBadgesResponseModel();

                        model.SetProperties(boBadges.Id, boBadges.Date, boBadges.Name, boBadges.UserId);

                        return model;
                }

                public virtual List<ApiBadgesResponseModel> MapBOToModel(
                        List<BOBadges> items)
                {
                        List<ApiBadgesResponseModel> response = new List<ApiBadgesResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>0f4f8e0ccccb2c59ec062dfed2b4dfce</Hash>
</Codenesium>*/