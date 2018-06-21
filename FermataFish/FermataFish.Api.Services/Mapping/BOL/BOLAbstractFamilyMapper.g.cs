using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public abstract class BOLAbstractFamilyMapper
        {
                public virtual BOFamily MapModelToBO(
                        int id,
                        ApiFamilyRequestModel model
                        )
                {
                        BOFamily boFamily = new BOFamily();
                        boFamily.SetProperties(
                                id,
                                model.Notes,
                                model.PcEmail,
                                model.PcFirstName,
                                model.PcLastName,
                                model.PcPhone,
                                model.StudioId);
                        return boFamily;
                }

                public virtual ApiFamilyResponseModel MapBOToModel(
                        BOFamily boFamily)
                {
                        var model = new ApiFamilyResponseModel();

                        model.SetProperties(boFamily.Id, boFamily.Notes, boFamily.PcEmail, boFamily.PcFirstName, boFamily.PcLastName, boFamily.PcPhone, boFamily.StudioId);

                        return model;
                }

                public virtual List<ApiFamilyResponseModel> MapBOToModel(
                        List<BOFamily> items)
                {
                        List<ApiFamilyResponseModel> response = new List<ApiFamilyResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>0bb48ddf31c36364f5588c68bb2caa11</Hash>
</Codenesium>*/