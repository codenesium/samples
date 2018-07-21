using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public abstract class DALAbstractSchemaBPersonMapper
        {
                public virtual SchemaBPerson MapBOToEF(
                        BOSchemaBPerson bo)
                {
                        SchemaBPerson efSchemaBPerson = new SchemaBPerson();
                        efSchemaBPerson.SetProperties(
                                bo.Id,
                                bo.Name);
                        return efSchemaBPerson;
                }

                public virtual BOSchemaBPerson MapEFToBO(
                        SchemaBPerson ef)
                {
                        var bo = new BOSchemaBPerson();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOSchemaBPerson> MapEFToBO(
                        List<SchemaBPerson> records)
                {
                        List<BOSchemaBPerson> response = new List<BOSchemaBPerson>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>72ac17f17375681e66f882b7af42185c</Hash>
</Codenesium>*/