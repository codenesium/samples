using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractEmployeeDepartmentHistoryMapper
        {
                public virtual EmployeeDepartmentHistory MapBOToEF(
                        BOEmployeeDepartmentHistory bo)
                {
                        EmployeeDepartmentHistory efEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
                        efEmployeeDepartmentHistory.SetProperties(
                                bo.BusinessEntityID,
                                bo.DepartmentID,
                                bo.EndDate,
                                bo.ModifiedDate,
                                bo.ShiftID,
                                bo.StartDate);
                        return efEmployeeDepartmentHistory;
                }

                public virtual BOEmployeeDepartmentHistory MapEFToBO(
                        EmployeeDepartmentHistory ef)
                {
                        var bo = new BOEmployeeDepartmentHistory();

                        bo.SetProperties(
                                ef.BusinessEntityID,
                                ef.DepartmentID,
                                ef.EndDate,
                                ef.ModifiedDate,
                                ef.ShiftID,
                                ef.StartDate);
                        return bo;
                }

                public virtual List<BOEmployeeDepartmentHistory> MapEFToBO(
                        List<EmployeeDepartmentHistory> records)
                {
                        List<BOEmployeeDepartmentHistory> response = new List<BOEmployeeDepartmentHistory>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>c5a288a279f95a27d9c34c6b098edc80</Hash>
</Codenesium>*/