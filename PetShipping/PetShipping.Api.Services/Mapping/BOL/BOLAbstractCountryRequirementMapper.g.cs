using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractCountryRequirementMapper
        {
                public virtual BOCountryRequirement MapModelToBO(
                        int id,
                        ApiCountryRequirementRequestModel model
                        )
                {
                        BOCountryRequirement boCountryRequirement = new BOCountryRequirement();

                        boCountryRequirement.SetProperties(
                                id,
                                model.CountryId,
                                model.Details);
                        return boCountryRequirement;
                }

                public virtual ApiCountryRequirementResponseModel MapBOToModel(
                        BOCountryRequirement boCountryRequirement)
                {
                        var model = new ApiCountryRequirementResponseModel();

                        model.SetProperties(boCountryRequirement.CountryId, boCountryRequirement.Details, boCountryRequirement.Id);

                        return model;
                }

                public virtual List<ApiCountryRequirementResponseModel> MapBOToModel(
                        List<BOCountryRequirement> items)
                {
                        List<ApiCountryRequirementResponseModel> response = new List<ApiCountryRequirementResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>59ab24bf1f23738c0236c2b3dcae4f46</Hash>
</Codenesium>*/