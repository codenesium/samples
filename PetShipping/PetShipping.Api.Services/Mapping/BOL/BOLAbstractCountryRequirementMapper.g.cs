using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>ba5ffbefb15bb20b9fed3c7973240555</Hash>
</Codenesium>*/