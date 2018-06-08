using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOStudentXFamily: AbstractBusinessObject
        {
                public BOStudentXFamily() : base()
                {
                }

                public void SetProperties(int id,
                                          int familyId,
                                          int studentId)
                {
                        this.FamilyId = familyId;
                        this.Id = id;
                        this.StudentId = studentId;
                }

                public int FamilyId { get; private set; }

                public int Id { get; private set; }

                public int StudentId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>179360135a68fc88f1085c23b67236a5</Hash>
</Codenesium>*/