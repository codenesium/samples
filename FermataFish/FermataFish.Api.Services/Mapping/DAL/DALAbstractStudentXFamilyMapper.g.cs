using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractStudentXFamilyMapper
        {
                public virtual StudentXFamily MapBOToEF(
                        BOStudentXFamily bo)
                {
                        StudentXFamily efStudentXFamily = new StudentXFamily();

                        efStudentXFamily.SetProperties(
                                bo.FamilyId,
                                bo.Id,
                                bo.StudentId);
                        return efStudentXFamily;
                }

                public virtual BOStudentXFamily MapEFToBO(
                        StudentXFamily ef)
                {
                        var bo = new BOStudentXFamily();

                        bo.SetProperties(
                                ef.Id,
                                ef.FamilyId,
                                ef.StudentId);
                        return bo;
                }

                public virtual List<BOStudentXFamily> MapEFToBO(
                        List<StudentXFamily> records)
                {
                        List<BOStudentXFamily> response = new List<BOStudentXFamily>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>9cf63f9998744659cd0649a6bb3294c0</Hash>
</Codenesium>*/