using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractDatabaseLogMapper
        {
                public virtual BODatabaseLog MapModelToBO(
                        int databaseLogID,
                        ApiDatabaseLogRequestModel model
                        )
                {
                        BODatabaseLog boDatabaseLog = new BODatabaseLog();

                        boDatabaseLog.SetProperties(
                                databaseLogID,
                                model.DatabaseUser,
                                model.@Event,
                                model.@Object,
                                model.PostTime,
                                model.Schema,
                                model.TSQL,
                                model.XmlEvent);
                        return boDatabaseLog;
                }

                public virtual ApiDatabaseLogResponseModel MapBOToModel(
                        BODatabaseLog boDatabaseLog)
                {
                        var model = new ApiDatabaseLogResponseModel();

                        model.SetProperties(boDatabaseLog.DatabaseLogID, boDatabaseLog.DatabaseUser, boDatabaseLog.@Event, boDatabaseLog.@Object, boDatabaseLog.PostTime, boDatabaseLog.Schema, boDatabaseLog.TSQL, boDatabaseLog.XmlEvent);

                        return model;
                }

                public virtual List<ApiDatabaseLogResponseModel> MapBOToModel(
                        List<BODatabaseLog> items)
                {
                        List<ApiDatabaseLogResponseModel> response = new List<ApiDatabaseLogResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4b7668a0cfe6cb4d66d3e8fc3a23a68b</Hash>
</Codenesium>*/