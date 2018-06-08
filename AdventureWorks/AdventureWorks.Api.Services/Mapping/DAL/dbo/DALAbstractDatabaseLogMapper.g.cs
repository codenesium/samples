using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractDatabaseLogMapper
        {
                public virtual DatabaseLog MapBOToEF(
                        BODatabaseLog bo)
                {
                        DatabaseLog efDatabaseLog = new DatabaseLog();

                        efDatabaseLog.SetProperties(
                                bo.DatabaseLogID,
                                bo.DatabaseUser,
                                bo.@Event,
                                bo.@Object,
                                bo.PostTime,
                                bo.Schema,
                                bo.TSQL,
                                bo.XmlEvent);
                        return efDatabaseLog;
                }

                public virtual BODatabaseLog MapEFToBO(
                        DatabaseLog ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BODatabaseLog();

                        bo.SetProperties(
                                ef.DatabaseLogID,
                                ef.DatabaseUser,
                                ef.@Event,
                                ef.@Object,
                                ef.PostTime,
                                ef.Schema,
                                ef.TSQL,
                                ef.XmlEvent);
                        return bo;
                }

                public virtual List<BODatabaseLog> MapEFToBO(
                        List<DatabaseLog> records)
                {
                        List<BODatabaseLog> response = new List<BODatabaseLog>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>487ff8ac2c23fb46f64a07164488af2e</Hash>
</Codenesium>*/