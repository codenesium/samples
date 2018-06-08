using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
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
                                model.ClientId,
                                model.Note,
                                model.PetId,
                                model.SaleDate,
                                model.SalesPersonId);
                        return boSale;
                }

                public virtual ApiSaleResponseModel MapBOToModel(
                        BOSale boSale)
                {
                        var model = new ApiSaleResponseModel();

                        model.SetProperties(boSale.Amount, boSale.ClientId, boSale.Id, boSale.Note, boSale.PetId, boSale.SaleDate, boSale.SalesPersonId);

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
    <Hash>ccb4bfd02dce17303cd66fbb0c38e252</Hash>
</Codenesium>*/