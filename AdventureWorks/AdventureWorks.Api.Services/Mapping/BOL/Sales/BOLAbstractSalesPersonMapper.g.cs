using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractSalesPersonMapper
        {
                public virtual BOSalesPerson MapModelToBO(
                        int businessEntityID,
                        ApiSalesPersonRequestModel model
                        )
                {
                        BOSalesPerson boSalesPerson = new BOSalesPerson();

                        boSalesPerson.SetProperties(
                                businessEntityID,
                                model.Bonus,
                                model.CommissionPct,
                                model.ModifiedDate,
                                model.Rowguid,
                                model.SalesLastYear,
                                model.SalesQuota,
                                model.SalesYTD,
                                model.TerritoryID);
                        return boSalesPerson;
                }

                public virtual ApiSalesPersonResponseModel MapBOToModel(
                        BOSalesPerson boSalesPerson)
                {
                        var model = new ApiSalesPersonResponseModel();

                        model.SetProperties(boSalesPerson.Bonus, boSalesPerson.BusinessEntityID, boSalesPerson.CommissionPct, boSalesPerson.ModifiedDate, boSalesPerson.Rowguid, boSalesPerson.SalesLastYear, boSalesPerson.SalesQuota, boSalesPerson.SalesYTD, boSalesPerson.TerritoryID);

                        return model;
                }

                public virtual List<ApiSalesPersonResponseModel> MapBOToModel(
                        List<BOSalesPerson> items)
                {
                        List<ApiSalesPersonResponseModel> response = new List<ApiSalesPersonResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e1dee1861718d22740520ae6537ba304</Hash>
</Codenesium>*/