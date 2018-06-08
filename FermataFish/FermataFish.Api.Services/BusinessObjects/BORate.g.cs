using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BORate:AbstractBusinessObject
        {
                public BORate() : base()
                {
                }

                public void SetProperties(int id,
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
    <Hash>0fbac6e4a80f9b475e792df49d32955f</Hash>
</Codenesium>*/