using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractVendorMapper
        {
                public virtual BOVendor MapModelToBO(
                        int businessEntityID,
                        ApiVendorRequestModel model
                        )
                {
                        BOVendor boVendor = new BOVendor();
                        boVendor.SetProperties(
                                businessEntityID,
                                model.AccountNumber,
                                model.ActiveFlag,
                                model.CreditRating,
                                model.ModifiedDate,
                                model.Name,
                                model.PreferredVendorStatus,
                                model.PurchasingWebServiceURL);
                        return boVendor;
                }

                public virtual ApiVendorResponseModel MapBOToModel(
                        BOVendor boVendor)
                {
                        var model = new ApiVendorResponseModel();

                        model.SetProperties(boVendor.BusinessEntityID, boVendor.AccountNumber, boVendor.ActiveFlag, boVendor.CreditRating, boVendor.ModifiedDate, boVendor.Name, boVendor.PreferredVendorStatus, boVendor.PurchasingWebServiceURL);

                        return model;
                }

                public virtual List<ApiVendorResponseModel> MapBOToModel(
                        List<BOVendor> items)
                {
                        List<ApiVendorResponseModel> response = new List<ApiVendorResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a37f7d1b6eba865b1039c0836ab9f148</Hash>
</Codenesium>*/