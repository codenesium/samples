using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractEmployeePayHistoryMapper
        {
                public virtual EmployeePayHistory MapBOToEF(
                        BOEmployeePayHistory bo)
                {
                        EmployeePayHistory efEmployeePayHistory = new EmployeePayHistory();

                        efEmployeePayHistory.SetProperties(
                                bo.BusinessEntityID,
                                bo.ModifiedDate,
                                bo.PayFrequency,
                                bo.Rate,
                                bo.RateChangeDate);
                        return efEmployeePayHistory;
                }

                public virtual BOEmployeePayHistory MapEFToBO(
                        EmployeePayHistory ef)
                {
                        var bo = new BOEmployeePayHistory();

                        bo.SetProperties(
                                ef.BusinessEntityID,
                                ef.ModifiedDate,
                                ef.PayFrequency,
                                ef.Rate,
                                ef.RateChangeDate);
                        return bo;
                }

                public virtual List<BOEmployeePayHistory> MapEFToBO(
                        List<EmployeePayHistory> records)
                {
                        List<BOEmployeePayHistory> response = new List<BOEmployeePayHistory>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>217c176c8ee803ab77ea3fee2ed59212</Hash>
</Codenesium>*/