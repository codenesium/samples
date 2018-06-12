using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractConfigurationMapper
        {
                public virtual Configuration MapBOToEF(
                        BOConfiguration bo)
                {
                        Configuration efConfiguration = new Configuration();

                        efConfiguration.SetProperties(
                                bo.Id,
                                bo.JSON);
                        return efConfiguration;
                }

                public virtual BOConfiguration MapEFToBO(
                        Configuration ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOConfiguration();

                        bo.SetProperties(
                                ef.Id,
                                ef.JSON);
                        return bo;
                }

                public virtual List<BOConfiguration> MapEFToBO(
                        List<Configuration> records)
                {
                        List<BOConfiguration> response = new List<BOConfiguration>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>dc9cc396c09aaf276aae2c39307025b2</Hash>
</Codenesium>*/