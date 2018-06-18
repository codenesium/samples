using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOTeacherSkill: AbstractBusinessObject
        {
                public AbstractBOTeacherSkill() : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>4ec3bed2e8714e6b7dee6b3b582fece2</Hash>
</Codenesium>*/