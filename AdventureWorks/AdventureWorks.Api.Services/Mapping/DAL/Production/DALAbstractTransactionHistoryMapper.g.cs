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
                        if (ef == null)
                        {
                                return null;
                        }

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
    <Hash>b86b7a0a8e445af730ef1f02a8d74609</Hash>
</Codenesium>*/