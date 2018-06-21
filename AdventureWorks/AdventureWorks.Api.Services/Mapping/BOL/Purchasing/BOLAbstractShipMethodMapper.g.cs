using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractShipMethodMapper
        {
                public virtual BOShipMethod MapModelToBO(
                        int shipMethodID,
                        ApiShipMethodRequestModel model
                        )
                {
                        BOShipMethod boShipMethod = new BOShipMethod();
                        boShipMethod.SetProperties(
                                shipMethodID,
                                model.ModifiedDate,
                                model.Name,
                                model.Rowguid,
                                model.ShipBase,
                                model.ShipRate);
                        return boShipMethod;
                }

                public virtual ApiShipMethodResponseModel MapBOToModel(
                        BOShipMethod boShipMethod)
                {
                        var model = new ApiShipMethodResponseModel();

                        model.SetProperties(boShipMethod.ModifiedDate, boShipMethod.Name, boShipMethod.Rowguid, boShipMethod.ShipBase, boShipMethod.ShipMethodID, boShipMethod.ShipRate);

                        return model;
                }

                public virtual List<ApiShipMethodResponseModel> MapBOToModel(
                        List<BOShipMethod> items)
                {
                        List<ApiShipMethodResponseModel> response = new List<ApiShipMethodResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>cf64ee7924440611343b7c0fc053dd04</Hash>
</Codenesium>*/