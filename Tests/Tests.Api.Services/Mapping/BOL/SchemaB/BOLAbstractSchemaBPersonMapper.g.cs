using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public abstract class BOLAbstractSchemaBPersonMapper
        {
                public virtual BOSchemaBPerson MapModelToBO(
                        int id,
                        ApiSchemaBPersonRequestModel model
                        )
                {
                        BOSchemaBPerson boSchemaBPerson = new BOSchemaBPerson();
                        boSchemaBPerson.SetProperties(
                                id,
                                model.Name);
                        return boSchemaBPerson;
                }

                public virtual ApiSchemaBPersonResponseModel MapBOToModel(
                        BOSchemaBPerson boSchemaBPerson)
                {
                        var model = new ApiSchemaBPersonResponseModel();

                        model.SetProperties(boSchemaBPerson.Id, boSchemaBPerson.Name);

                        return model;
                }

                public virtual List<ApiSchemaBPersonResponseModel> MapBOToModel(
                        List<BOSchemaBPerson> items)
                {
                        List<ApiSchemaBPersonResponseModel> response = new List<ApiSchemaBPersonResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4801f9810499cdb20a1473cee2ba741c</Hash>
</Codenesium>*/