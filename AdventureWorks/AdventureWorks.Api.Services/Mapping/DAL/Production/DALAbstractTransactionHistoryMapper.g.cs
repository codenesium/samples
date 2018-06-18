using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractTransactionHistoryMapper
        {
                public virtual TransactionHistory MapBOToEF(
                        BOTransactionHistory bo)
                {
                        TransactionHistory efTransactionHistory = new TransactionHistory();

                        efTransactionHistory.SetProperties(
                                bo.ActualCost,
                                bo.ModifiedDate,
                                bo.ProductID,
                                bo.Quantity,
                                bo.ReferenceOrderID,
                                bo.ReferenceOrderLineID,
                                bo.TransactionDate,
                                bo.TransactionID,
                                bo.TransactionType);
                        return efTransactionHistory;
                }

                public virtual BOTransactionHistory MapEFToBO(
                        TransactionHistory ef)
                {
                        var bo = new BOTransactionHistory();

                        bo.SetProperties(
                                ef.TransactionID,
                                ef.ActualCost,
                                ef.ModifiedDate,
                                ef.ProductID,
                                ef.Quantity,
                                ef.ReferenceOrderID,
                                ef.ReferenceOrderLineID,
                                ef.TransactionDate,
                                ef.TransactionType);
                        return bo;
                }

                public virtual List<BOTransactionHistory> MapEFToBO(
                        List<TransactionHistory> records)
                {
                        List<BOTransactionHistory> response = new List<BOTransactionHistory>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6e8117bf486db8b86d3496ba99d1862e</Hash>
</Codenesium>*/