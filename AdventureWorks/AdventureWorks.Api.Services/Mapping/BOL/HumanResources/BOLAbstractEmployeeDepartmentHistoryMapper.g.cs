using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractEmployeeDepartmentHistoryMapper
        {
                public virtual BOEmployeeDepartmentHistory MapModelToBO(
                        int businessEntityID,
                        ApiEmployeeDepartmentHistoryRequestModel model
                        )
                {
                        BOEmployeeDepartmentHistory boEmployeeDepartmentHistory = new BOEmployeeDepartmentHistory();
                        boEmployeeDepartmentHistory.SetProperties(
                                businessEntityID,
                                model.DepartmentID,
                                model.EndDate,
                                model.ModifiedDate,
                                model.ShiftID,
                                model.StartDate);
                        return boEmployeeDepartmentHistory;
                }

                public virtual ApiEmployeeDepartmentHistoryResponseModel MapBOToModel(
                        BOEmployeeDepartmentHistory boEmployeeDepartmentHistory)
                {
                        var model = new ApiEmployeeDepartmentHistoryResponseModel();

                        model.SetProperties(boEmployeeDepartmentHistory.BusinessEntityID, boEmployeeDepartmentHistory.DepartmentID, boEmployeeDepartmentHistory.EndDate, boEmployeeDepartmentHistory.ModifiedDate, boEmployeeDepartmentHistory.ShiftID, boEmployeeDepartmentHistory.StartDate);

                        return model;
                }

                public virtual List<ApiEmployeeDepartmentHistoryResponseModel> MapBOToModel(
                        List<BOEmployeeDepartmentHistory> items)
                {
                        List<ApiEmployeeDepartmentHistoryResponseModel> response = new List<ApiEmployeeDepartmentHistoryResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>0fb3090ad2d28f1269d079012a47628f</Hash>
</Codenesium>*/