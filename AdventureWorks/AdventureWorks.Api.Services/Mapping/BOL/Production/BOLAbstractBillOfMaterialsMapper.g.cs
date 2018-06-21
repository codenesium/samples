using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractBillOfMaterialsMapper
        {
                public virtual BOBillOfMaterials MapModelToBO(
                        int billOfMaterialsID,
                        ApiBillOfMaterialsRequestModel model
                        )
                {
                        BOBillOfMaterials boBillOfMaterials = new BOBillOfMaterials();
                        boBillOfMaterials.SetProperties(
                                billOfMaterialsID,
                                model.BOMLevel,
                                model.ComponentID,
                                model.EndDate,
                                model.ModifiedDate,
                                model.PerAssemblyQty,
                                model.ProductAssemblyID,
                                model.StartDate,
                                model.UnitMeasureCode);
                        return boBillOfMaterials;
                }

                public virtual ApiBillOfMaterialsResponseModel MapBOToModel(
                        BOBillOfMaterials boBillOfMaterials)
                {
                        var model = new ApiBillOfMaterialsResponseModel();

                        model.SetProperties(boBillOfMaterials.BillOfMaterialsID, boBillOfMaterials.BOMLevel, boBillOfMaterials.ComponentID, boBillOfMaterials.EndDate, boBillOfMaterials.ModifiedDate, boBillOfMaterials.PerAssemblyQty, boBillOfMaterials.ProductAssemblyID, boBillOfMaterials.StartDate, boBillOfMaterials.UnitMeasureCode);

                        return model;
                }

                public virtual List<ApiBillOfMaterialsResponseModel> MapBOToModel(
                        List<BOBillOfMaterials> items)
                {
                        List<ApiBillOfMaterialsResponseModel> response = new List<ApiBillOfMaterialsResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>84ec1e3584ba0e3447b712be5dab5912</Hash>
</Codenesium>*/