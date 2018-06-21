using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractSalesPersonQuotaHistoryMapper
        {
                public virtual BOSalesPersonQuotaHistory MapModelToBO(
                        int businessEntityID,
                        ApiSalesPersonQuotaHistoryRequestModel model
                        )
                {
                        BOSalesPersonQuotaHistory boSalesPersonQuotaHistory = new BOSalesPersonQuotaHistory();
                        boSalesPersonQuotaHistory.SetProperties(
                                businessEntityID,
                                model.ModifiedDate,
                                model.QuotaDate,
                                model.Rowguid,
                                model.SalesQuota);
                        return boSalesPersonQuotaHistory;
                }

                public virtual ApiSalesPersonQuotaHistoryResponseModel MapBOToModel(
                        BOSalesPersonQuotaHistory boSalesPersonQuotaHistory)
                {
                        var model = new ApiSalesPersonQuotaHistoryResponseModel();

                        model.SetProperties(boSalesPersonQuotaHistory.BusinessEntityID, boSalesPersonQuotaHistory.ModifiedDate, boSalesPersonQuotaHistory.QuotaDate, boSalesPersonQuotaHistory.Rowguid, boSalesPersonQuotaHistory.SalesQuota);

                        return model;
                }

                public virtual List<ApiSalesPersonQuotaHistoryResponseModel> MapBOToModel(
                        List<BOSalesPersonQuotaHistory> items)
                {
                        List<ApiSalesPersonQuotaHistoryResponseModel> response = new List<ApiSalesPersonQuotaHistoryResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>729b620589451f4651a867e7f6cc22f2</Hash>
</Codenesium>*/