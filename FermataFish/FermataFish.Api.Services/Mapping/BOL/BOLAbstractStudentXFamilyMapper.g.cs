using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class BOLAbstractStudentXFamilyMapper
        {
                public virtual BOStudentXFamily MapModelToBO(
                        int id,
                        ApiStudentXFamilyRequestModel model
                        )
                {
                        BOStudentXFamily boStudentXFamily = new BOStudentXFamily();

                        boStudentXFamily.SetProperties(
                                id,
                                model.FamilyId,
                                model.StudentId);
                        return boStudentXFamily;
                }

                public virtual ApiStudentXFamilyResponseModel MapBOToModel(
                        BOStudentXFamily boStudentXFamily)
                {
                        var model = new ApiStudentXFamilyResponseModel();

                        model.SetProperties(boStudentXFamily.FamilyId, boStudentXFamily.Id, boStudentXFamily.StudentId);

                        return model;
                }

                public virtual List<ApiStudentXFamilyResponseModel> MapBOToModel(
                        List<BOStudentXFamily> items)
                {
                        List<ApiStudentXFamilyResponseModel> response = new List<ApiStudentXFamilyResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6ca48fa62941eca897165899d20f15c1</Hash>
</Codenesium>*/