using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>0f3fb48dc3f6751ed093013b019b637c</Hash>
</Codenesium>*/