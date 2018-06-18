using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "StudentXFamily")]
        [Trait("Area", "DALMapper")]
        public class TestDALStudentXFamilyActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALStudentXFamilyMapper();

                        var bo = new BOStudentXFamily();

                        bo.SetProperties(1, 1, 1);

                        StudentXFamily response = mapper.MapBOToEF(bo);

                        response.FamilyId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALStudentXFamilyMapper();

                        StudentXFamily entity = new StudentXFamily();

                        entity.SetProperties(1, 1, 1);

                        BOStudentXFamily  response = mapper.MapEFToBO(entity);

                        response.FamilyId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALStudentXFamilyMapper();

                        StudentXFamily entity = new StudentXFamily();

                        entity.SetProperties(1, 1, 1);

                        List<BOStudentXFamily> response = mapper.MapEFToBO(new List<StudentXFamily>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>f5d8c4f6d7d5ac26df9d75b1c1cbde85</Hash>
</Codenesium>*/