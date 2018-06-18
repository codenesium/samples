using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractBillOfMaterialsMapper
        {
                public virtual BillOfMaterials MapBOToEF(
                        BOBillOfMaterials bo)
                {
                        BillOfMaterials efBillOfMaterials = new BillOfMaterials();

                        efBillOfMaterials.SetProperties(
                                bo.BillOfMaterialsID,
                                bo.BOMLevel,
                                bo.ComponentID,
                                bo.EndDate,
                                bo.ModifiedDate,
                                bo.PerAssemblyQty,
                                bo.ProductAssemblyID,
                                bo.StartDate,
                                bo.UnitMeasureCode);
                        return efBillOfMaterials;
                }

                public virtual BOBillOfMaterials MapEFToBO(
                        BillOfMaterials ef)
                {
                        var bo = new BOBillOfMaterials();

                        bo.SetProperties(
                                ef.BillOfMaterialsID,
                                ef.BOMLevel,
                                ef.ComponentID,
                                ef.EndDate,
                                ef.ModifiedDate,
                                ef.PerAssemblyQty,
                                ef.ProductAssemblyID,
                                ef.StartDate,
                                ef.UnitMeasureCode);
                        return bo;
                }

                public virtual List<BOBillOfMaterials> MapEFToBO(
                        List<BillOfMaterials> records)
                {
                        List<BOBillOfMaterials> response = new List<BOBillOfMaterials>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b7476698243599740a7c2bdde437181b</Hash>
</Codenesium>*/