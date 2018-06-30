using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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

                        model.SetProperties(boStudentXFamily.Id, boStudentXFamily.FamilyId, boStudentXFamily.StudentId);

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
    <Hash>038c13f90f76e9570aa0f3f1f7518af8</Hash>
</Codenesium>*/