using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public abstract class DALAbstractPenMapper
        {
                public virtual Pen MapBOToEF(
                        BOPen bo)
                {
                        Pen efPen = new Pen();

                        efPen.SetProperties(
                                bo.Id,
                                bo.Name);
                        return efPen;
                }

                public virtual BOPen MapEFToBO(
                        Pen ef)
                {
                        var bo = new BOPen();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOPen> MapEFToBO(
                        List<Pen> records)
                {
                        List<BOPen> response = new List<BOPen>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6019fb4b531401a0c74e0e3a601e8fbe</Hash>
</Codenesium>*/