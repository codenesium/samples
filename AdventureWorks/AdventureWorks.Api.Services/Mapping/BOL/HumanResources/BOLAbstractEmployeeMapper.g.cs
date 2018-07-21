using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractEmployeeMapper
        {
                public virtual BOEmployee MapModelToBO(
                        int businessEntityID,
                        ApiEmployeeRequestModel model
                        )
                {
                        BOEmployee boEmployee = new BOEmployee();
                        boEmployee.SetProperties(
                                businessEntityID,
                                model.BirthDate,
                                model.CurrentFlag,
                                model.Gender,
                                model.HireDate,
                                model.JobTitle,
                                model.LoginID,
                                model.MaritalStatu,
                                model.ModifiedDate,
                                model.NationalIDNumber,
                                model.OrganizationLevel,
                                model.Rowguid,
                                model.SalariedFlag,
                                model.SickLeaveHour,
                                model.VacationHour);
                        return boEmployee;
                }

                public virtual ApiEmployeeResponseModel MapBOToModel(
                        BOEmployee boEmployee)
                {
                        var model = new ApiEmployeeResponseModel();

                        model.SetProperties(boEmployee.BusinessEntityID, boEmployee.BirthDate, boEmployee.CurrentFlag, boEmployee.Gender, boEmployee.HireDate, boEmployee.JobTitle, boEmployee.LoginID, boEmployee.MaritalStatu, boEmployee.ModifiedDate, boEmployee.NationalIDNumber, boEmployee.OrganizationLevel, boEmployee.Rowguid, boEmployee.SalariedFlag, boEmployee.SickLeaveHour, boEmployee.VacationHour);

                        return model;
                }

                public virtual List<ApiEmployeeResponseModel> MapBOToModel(
                        List<BOEmployee> items)
                {
                        List<ApiEmployeeResponseModel> response = new List<ApiEmployeeResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b1157f27a9519ac93efc4a561913ac87</Hash>
</Codenesium>*/