using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractNuGetPackageMapper
        {
                public virtual BONuGetPackage MapModelToBO(
                        string id,
                        ApiNuGetPackageRequestModel model
                        )
                {
                        BONuGetPackage boNuGetPackage = new BONuGetPackage();
                        boNuGetPackage.SetProperties(
                                id,
                                model.JSON,
                                model.PackageId,
                                model.Version,
                                model.VersionBuild,
                                model.VersionMajor,
                                model.VersionMinor,
                                model.VersionRevision,
                                model.VersionSpecial);
                        return boNuGetPackage;
                }

                public virtual ApiNuGetPackageResponseModel MapBOToModel(
                        BONuGetPackage boNuGetPackage)
                {
                        var model = new ApiNuGetPackageResponseModel();

                        model.SetProperties(boNuGetPackage.Id, boNuGetPackage.JSON, boNuGetPackage.PackageId, boNuGetPackage.Version, boNuGetPackage.VersionBuild, boNuGetPackage.VersionMajor, boNuGetPackage.VersionMinor, boNuGetPackage.VersionRevision, boNuGetPackage.VersionSpecial);

                        return model;
                }

                public virtual List<ApiNuGetPackageResponseModel> MapBOToModel(
                        List<BONuGetPackage> items)
                {
                        List<ApiNuGetPackageResponseModel> response = new List<ApiNuGetPackageResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ec530d007f8bcb2ae7d147a3e8900647</Hash>
</Codenesium>*/