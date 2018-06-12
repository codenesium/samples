using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractLibraryVariableSetMapper
        {
                public virtual BOLibraryVariableSet MapModelToBO(
                        string id,
                        ApiLibraryVariableSetRequestModel model
                        )
                {
                        BOLibraryVariableSet boLibraryVariableSet = new BOLibraryVariableSet();

                        boLibraryVariableSet.SetProperties(
                                id,
                                model.ContentType,
                                model.JSON,
                                model.Name,
                                model.VariableSetId);
                        return boLibraryVariableSet;
                }

                public virtual ApiLibraryVariableSetResponseModel MapBOToModel(
                        BOLibraryVariableSet boLibraryVariableSet)
                {
                        var model = new ApiLibraryVariableSetResponseModel();

                        model.SetProperties(boLibraryVariableSet.ContentType, boLibraryVariableSet.Id, boLibraryVariableSet.JSON, boLibraryVariableSet.Name, boLibraryVariableSet.VariableSetId);

                        return model;
                }

                public virtual List<ApiLibraryVariableSetResponseModel> MapBOToModel(
                        List<BOLibraryVariableSet> items)
                {
                        List<ApiLibraryVariableSetResponseModel> response = new List<ApiLibraryVariableSetResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4ec05985d119d1061cd5cc71a3135cb8</Hash>
</Codenesium>*/