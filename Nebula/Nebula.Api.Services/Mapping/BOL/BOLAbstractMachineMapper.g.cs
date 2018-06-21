using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public abstract class BOLAbstractMachineMapper
        {
                public virtual BOMachine MapModelToBO(
                        int id,
                        ApiMachineRequestModel model
                        )
                {
                        BOMachine boMachine = new BOMachine();
                        boMachine.SetProperties(
                                id,
                                model.Description,
                                model.JwtKey,
                                model.LastIpAddress,
                                model.MachineGuid,
                                model.Name);
                        return boMachine;
                }

                public virtual ApiMachineResponseModel MapBOToModel(
                        BOMachine boMachine)
                {
                        var model = new ApiMachineResponseModel();

                        model.SetProperties(boMachine.Description, boMachine.Id, boMachine.JwtKey, boMachine.LastIpAddress, boMachine.MachineGuid, boMachine.Name);

                        return model;
                }

                public virtual List<ApiMachineResponseModel> MapBOToModel(
                        List<BOMachine> items)
                {
                        List<ApiMachineResponseModel> response = new List<ApiMachineResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4681be9ac6cb1d32624922eff5e71e73</Hash>
</Codenesium>*/