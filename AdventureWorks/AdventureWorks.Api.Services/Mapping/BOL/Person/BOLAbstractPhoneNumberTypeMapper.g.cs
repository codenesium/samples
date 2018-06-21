using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractPhoneNumberTypeMapper
        {
                public virtual BOPhoneNumberType MapModelToBO(
                        int phoneNumberTypeID,
                        ApiPhoneNumberTypeRequestModel model
                        )
                {
                        BOPhoneNumberType boPhoneNumberType = new BOPhoneNumberType();
                        boPhoneNumberType.SetProperties(
                                phoneNumberTypeID,
                                model.ModifiedDate,
                                model.Name);
                        return boPhoneNumberType;
                }

                public virtual ApiPhoneNumberTypeResponseModel MapBOToModel(
                        BOPhoneNumberType boPhoneNumberType)
                {
                        var model = new ApiPhoneNumberTypeResponseModel();

                        model.SetProperties(boPhoneNumberType.ModifiedDate, boPhoneNumberType.Name, boPhoneNumberType.PhoneNumberTypeID);

                        return model;
                }

                public virtual List<ApiPhoneNumberTypeResponseModel> MapBOToModel(
                        List<BOPhoneNumberType> items)
                {
                        List<ApiPhoneNumberTypeResponseModel> response = new List<ApiPhoneNumberTypeResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>36beb4bbb28fe019d57e28e9bae2cfc9</Hash>
</Codenesium>*/