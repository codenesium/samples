using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBORate : AbstractBusinessObject
        {
                public AbstractBORate()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  decimal amountPerMinute,
                                                  int teacherId,
                                                  int teacherSkillId)
                {
                        this.AmountPerMinute = amountPerMinute;
                        this.Id = id;
                        this.TeacherId = teacherId;
                        this.TeacherSkillId = teacherSkillId;
                }

                public decimal AmountPerMinute { get; private set; }

                public int Id { get; private set; }

                public int TeacherId { get; private set; }

                public int TeacherSkillId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6ad8303b6bb55d6475a4e730a99b6eef</Hash>
</Codenesium>*/