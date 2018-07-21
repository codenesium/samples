using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public abstract class DALAbstractSchemaAPersonMapper
        {
                public virtual SchemaAPerson MapBOToEF(
                        BOSchemaAPerson bo)
                {
                        SchemaAPerson efSchemaAPerson = new SchemaAPerson();
                        efSchemaAPerson.SetProperties(
                                bo.Id,
                                bo.Name);
                        return efSchemaAPerson;
                }

                public virtual BOSchemaAPerson MapEFToBO(
                        SchemaAPerson ef)
                {
                        var bo = new BOSchemaAPerson();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOSchemaAPerson> MapEFToBO(
                        List<SchemaAPerson> records)
                {
                        List<BOSchemaAPerson> response = new List<BOSchemaAPerson>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>531e0c2a3e5c1ecd39bac9913584ba93</Hash>
</Codenesium>*/