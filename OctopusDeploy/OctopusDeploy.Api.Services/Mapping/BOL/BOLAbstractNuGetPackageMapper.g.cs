using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>f4e8a710b320ddee36b056876011ebab</Hash>
</Codenesium>*/