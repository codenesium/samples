using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOStudentXFamily : AbstractBusinessObject
        {
                public AbstractBOStudentXFamily()
                        : base()
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
    <Hash>d75a7e89a0ec8b730c3cd6bfa57ebe37</Hash>
</Codenesium>*/