using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractPersonPhoneMapper
        {
                public virtual BOPersonPhone MapModelToBO(
                        int businessEntityID,
                        ApiPersonPhoneRequestModel model
                        )
                {
                        BOPersonPhone boPersonPhone = new BOPersonPhone();

                        boPersonPhone.SetProperties(
                                businessEntityID,
                                model.ModifiedDate,
                                model.PhoneNumber,
                                model.PhoneNumberTypeID);
                        return boPersonPhone;
                }

                public virtual ApiPersonPhoneResponseModel MapBOToModel(
                        BOPersonPhone boPersonPhone)
                {
                        var model = new ApiPersonPhoneResponseModel();

                        model.SetProperties(boPersonPhone.BusinessEntityID, boPersonPhone.ModifiedDate, boPersonPhone.PhoneNumber, boPersonPhone.PhoneNumberTypeID);

                        return model;
                }

                public virtual List<ApiPersonPhoneResponseModel> MapBOToModel(
                        List<BOPersonPhone> items)
                {
                        List<ApiPersonPhoneResponseModel> response = new List<ApiPersonPhoneResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>7cc8f0c8e2177bda9332e539c5a21417</Hash>
</Codenesium>*/