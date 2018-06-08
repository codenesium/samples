using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public abstract class BOLAbstractSaleMapper
        {
                public virtual BOSale MapModelToBO(
                        int id,
                        ApiSaleRequestModel model
                        )
                {
                        BOSale boSale = new BOSale();

                        boSale.SetProperties(
                                id,
                                model.Amount,
                                model.FirstName,
                                model.LastName,
                                model.PaymentTypeId,
                                model.PetId,
                                model.Phone);
                        return boSale;
                }

                public virtual ApiSaleResponseModel MapBOToModel(
                        BOSale boSale)
                {
                        var model = new ApiSaleResponseModel();

                        model.SetProperties(boSale.Amount, boSale.FirstName, boSale.Id, boSale.LastName, boSale.PaymentTypeId, boSale.PetId, boSale.Phone);

                        return model;
                }

                public virtual List<ApiSaleResponseModel> MapBOToModel(
                        List<BOSale> items)
                {
                        List<ApiSaleResponseModel> response = new List<ApiSaleResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e5970130964dd2131310853d92b5d7a8</Hash>
</Codenesium>*/