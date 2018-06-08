using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractDepartmentMapper
        {
                public virtual Department MapBOToEF(
                        BODepartment bo)
                {
                        Department efDepartment = new Department();

                        efDepartment.SetProperties(
                                bo.DepartmentID,
                                bo.GroupName,
                                bo.ModifiedDate,
                                bo.Name);
                        return efDepartment;
                }

                public virtual BODepartment MapEFToBO(
                        Department ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BODepartment();

                        bo.SetProperties(
                                ef.DepartmentID,
                                ef.GroupName,
                                ef.ModifiedDate,
                                ef.Name);
                        return bo;
                }

                public virtual List<BODepartment> MapEFToBO(
                        List<Department> records)
                {
                        List<BODepartment> response = new List<BODepartment>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>315d79a79745c9cb25328e985af080a9</Hash>
</Codenesium>*/