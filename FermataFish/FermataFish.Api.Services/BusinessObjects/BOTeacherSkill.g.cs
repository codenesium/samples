using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOTeacherSkill: AbstractBusinessObject
        {
                public BOTeacherSkill() : base()
                {
                }

                public void SetProperties(int id,
                                          string name,
                                          int studioId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.StudioId = studioId;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int StudioId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>df4a26a7ea0b1f2e67b36e02e73d6f99</Hash>
</Codenesium>*/