using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractExtensionConfigurationMapper
        {
                public virtual ExtensionConfiguration MapBOToEF(
                        BOExtensionConfiguration bo)
                {
                        ExtensionConfiguration efExtensionConfiguration = new ExtensionConfiguration();

                        efExtensionConfiguration.SetProperties(
                                bo.ExtensionAuthor,
                                bo.Id,
                                bo.JSON,
                                bo.Name);
                        return efExtensionConfiguration;
                }

                public virtual BOExtensionConfiguration MapEFToBO(
                        ExtensionConfiguration ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOExtensionConfiguration();

                        bo.SetProperties(
                                ef.Id,
                                ef.ExtensionAuthor,
                                ef.JSON,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOExtensionConfiguration> MapEFToBO(
                        List<ExtensionConfiguration> records)
                {
                        List<BOExtensionConfiguration> response = new List<BOExtensionConfiguration>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>939643ba9cc0b28920ee42b7945d07b8</Hash>
</Codenesium>*/