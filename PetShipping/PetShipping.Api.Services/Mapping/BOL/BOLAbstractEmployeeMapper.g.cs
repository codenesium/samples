using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractEmployeeMapper
        {
                public virtual BOEmployee MapModelToBO(
                        int id,
                        ApiEmployeeRequestModel model
                        )
                {
                        BOEmployee boEmployee = new BOEmployee();
                        boEmployee.SetProperties(
                                id,
                                model.FirstName,
                                model.IsSalesPerson,
                                model.IsShipper,
                                model.LastName);
                        return boEmployee;
                }

                public virtual ApiEmployeeResponseModel MapBOToModel(
                        BOEmployee boEmployee)
                {
                        var model = new ApiEmployeeResponseModel();

                        model.SetProperties(boEmployee.FirstName, boEmployee.Id, boEmployee.IsSalesPerson, boEmployee.IsShipper, boEmployee.LastName);

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
    <Hash>ee9eb2d526e90149d98fffdc6a74d293</Hash>
</Codenesium>*/