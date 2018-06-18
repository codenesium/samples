using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "StudentXFamily")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLStudentXFamilyActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLStudentXFamilyMapper();

                        ApiStudentXFamilyRequestModel model = new ApiStudentXFamilyRequestModel();

                        model.SetProperties(1, 1);
                        BOStudentXFamily response = mapper.MapModelToBO(1, model);

                        response.FamilyId.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLStudentXFamilyMapper();

                        BOStudentXFamily bo = new BOStudentXFamily();

                        bo.SetProperties(1, 1, 1);
                        ApiStudentXFamilyResponseModel response = mapper.MapBOToModel(bo);

                        response.FamilyId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLStudentXFamilyMapper();

                        BOStudentXFamily bo = new BOStudentXFamily();

                        bo.SetProperties(1, 1, 1);
                        List<ApiStudentXFamilyResponseModel> response = mapper.MapBOToModel(new List<BOStudentXFamily>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>c0c699554329bf4e051a6c6b1f0d9157</Hash>
</Codenesium>*/