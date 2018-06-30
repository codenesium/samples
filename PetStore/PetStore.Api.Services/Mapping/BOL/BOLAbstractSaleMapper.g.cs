using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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

                        model.SetProperties(boSale.Id, boSale.Amount, boSale.FirstName, boSale.LastName, boSale.PaymentTypeId, boSale.PetId, boSale.Phone);

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
    <Hash>9d81f0b8ae618c27866fb8db9694a45c</Hash>
</Codenesium>*/