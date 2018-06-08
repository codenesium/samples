using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractErrorLogMapper
        {
                public virtual BOErrorLog MapModelToBO(
                        int errorLogID,
                        ApiErrorLogRequestModel model
                        )
                {
                        BOErrorLog boErrorLog = new BOErrorLog();

                        boErrorLog.SetProperties(
                                errorLogID,
                                model.ErrorLine,
                                model.ErrorMessage,
                                model.ErrorNumber,
                                model.ErrorProcedure,
                                model.ErrorSeverity,
                                model.ErrorState,
                                model.ErrorTime,
                                model.UserName);
                        return boErrorLog;
                }

                public virtual ApiErrorLogResponseModel MapBOToModel(
                        BOErrorLog boErrorLog)
                {
                        var model = new ApiErrorLogResponseModel();

                        model.SetProperties(boErrorLog.ErrorLine, boErrorLog.ErrorLogID, boErrorLog.ErrorMessage, boErrorLog.ErrorNumber, boErrorLog.ErrorProcedure, boErrorLog.ErrorSeverity, boErrorLog.ErrorState, boErrorLog.ErrorTime, boErrorLog.UserName);

                        return model;
                }

                public virtual List<ApiErrorLogResponseModel> MapBOToModel(
                        List<BOErrorLog> items)
                {
                        List<ApiErrorLogResponseModel> response = new List<ApiErrorLogResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>f91c02327b23d869b783ddef65aef67f</Hash>
</Codenesium>*/