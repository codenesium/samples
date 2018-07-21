using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractBillOfMaterialMapper
        {
                public virtual BillOfMaterial MapBOToEF(
                        BOBillOfMaterial bo)
                {
                        BillOfMaterial efBillOfMaterial = new BillOfMaterial();
                        efBillOfMaterial.SetProperties(
                                bo.BillOfMaterialsID,
                                bo.BOMLevel,
                                bo.ComponentID,
                                bo.EndDate,
                                bo.ModifiedDate,
                                bo.PerAssemblyQty,
                                bo.ProductAssemblyID,
                                bo.StartDate,
                                bo.UnitMeasureCode);
                        return efBillOfMaterial;
                }

                public virtual BOBillOfMaterial MapEFToBO(
                        BillOfMaterial ef)
                {
                        var bo = new BOBillOfMaterial();

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

                public virtual List<BOBillOfMaterial> MapEFToBO(
                        List<BillOfMaterial> records)
                {
                        List<BOBillOfMaterial> response = new List<BOBillOfMaterial>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>9d47befc767d95628d3efe5f85ccc615</Hash>
</Codenesium>*/