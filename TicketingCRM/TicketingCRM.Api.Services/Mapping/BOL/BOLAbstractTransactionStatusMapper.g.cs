using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class BOLAbstractTransactionStatusMapper
        {
                public virtual BOTransactionStatus MapModelToBO(
                        int id,
                        ApiTransactionStatusRequestModel model
                        )
                {
                        BOTransactionStatus boTransactionStatus = new BOTransactionStatus();

                        boTransactionStatus.SetProperties(
                                id,
                                model.Name);
                        return boTransactionStatus;
                }

                public virtual ApiTransactionStatusResponseModel MapBOToModel(
                        BOTransactionStatus boTransactionStatus)
                {
                        var model = new ApiTransactionStatusResponseModel();

                        model.SetProperties(boTransactionStatus.Id, boTransactionStatus.Name);

                        return model;
                }

                public virtual List<ApiTransactionStatusResponseModel> MapBOToModel(
                        List<BOTransactionStatus> items)
                {
                        List<ApiTransactionStatusResponseModel> response = new List<ApiTransactionStatusResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>cad493a8a41298d2761d3379855ae7a0</Hash>
</Codenesium>*/