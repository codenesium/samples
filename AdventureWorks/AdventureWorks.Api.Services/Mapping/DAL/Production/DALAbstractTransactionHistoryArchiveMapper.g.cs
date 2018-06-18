using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractTransactionHistoryArchiveMapper
        {
                public virtual TransactionHistoryArchive MapBOToEF(
                        BOTransactionHistoryArchive bo)
                {
                        TransactionHistoryArchive efTransactionHistoryArchive = new TransactionHistoryArchive();

                        efTransactionHistoryArchive.SetProperties(
                                bo.ActualCost,
                                bo.ModifiedDate,
                                bo.ProductID,
                                bo.Quantity,
                                bo.ReferenceOrderID,
                                bo.ReferenceOrderLineID,
                                bo.TransactionDate,
                                bo.TransactionID,
                                bo.TransactionType);
                        return efTransactionHistoryArchive;
                }

                public virtual BOTransactionHistoryArchive MapEFToBO(
                        TransactionHistoryArchive ef)
                {
                        var bo = new BOTransactionHistoryArchive();

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

                public virtual List<BOTransactionHistoryArchive> MapEFToBO(
                        List<TransactionHistoryArchive> records)
                {
                        List<BOTransactionHistoryArchive> response = new List<BOTransactionHistoryArchive>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>86a75044277bf406b6abecd2b1964054</Hash>
</Codenesium>*/