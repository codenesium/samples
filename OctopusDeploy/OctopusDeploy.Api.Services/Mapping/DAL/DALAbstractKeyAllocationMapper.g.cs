using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractKeyAllocationMapper
        {
                public virtual KeyAllocation MapBOToEF(
                        BOKeyAllocation bo)
                {
                        KeyAllocation efKeyAllocation = new KeyAllocation();

                        efKeyAllocation.SetProperties(
                                bo.Allocated,
                                bo.CollectionName);
                        return efKeyAllocation;
                }

                public virtual BOKeyAllocation MapEFToBO(
                        KeyAllocation ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOKeyAllocation();

                        bo.SetProperties(
                                ef.CollectionName,
                                ef.Allocated);
                        return bo;
                }

                public virtual List<BOKeyAllocation> MapEFToBO(
                        List<KeyAllocation> records)
                {
                        List<BOKeyAllocation> response = new List<BOKeyAllocation>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>030a5a9331d62325c16e5ad007541ee3</Hash>
</Codenesium>*/