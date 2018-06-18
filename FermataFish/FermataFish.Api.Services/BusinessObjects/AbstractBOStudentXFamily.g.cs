using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOStudentXFamily: AbstractBusinessObject
        {
                public AbstractBOStudentXFamily() : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>6723cbfccd56c975cf03699814d4c2e0</Hash>
</Codenesium>*/