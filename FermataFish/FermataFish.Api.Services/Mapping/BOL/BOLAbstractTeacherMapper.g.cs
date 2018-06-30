using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public abstract class BOLAbstractTeacherMapper
        {
                public virtual BOTeacher MapModelToBO(
                        int id,
                        ApiTeacherRequestModel model
                        )
                {
                        BOTeacher boTeacher = new BOTeacher();
                        boTeacher.SetProperties(
                                id,
                                model.Birthday,
                                model.Email,
                                model.FirstName,
                                model.LastName,
                                model.Phone,
                                model.StudioId);
                        return boTeacher;
                }

                public virtual ApiTeacherResponseModel MapBOToModel(
                        BOTeacher boTeacher)
                {
                        var model = new ApiTeacherResponseModel();

                        model.SetProperties(boTeacher.Id, boTeacher.Birthday, boTeacher.Email, boTeacher.FirstName, boTeacher.LastName, boTeacher.Phone, boTeacher.StudioId);

                        return model;
                }

                public virtual List<ApiTeacherResponseModel> MapBOToModel(
                        List<BOTeacher> items)
                {
                        List<ApiTeacherResponseModel> response = new List<ApiTeacherResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b58bd3aa567cbc62c548946f34aad4b4</Hash>
</Codenesium>*/