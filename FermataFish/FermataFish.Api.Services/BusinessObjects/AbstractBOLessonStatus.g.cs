using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOLessonStatus: AbstractBusinessObject
        {
                public AbstractBOLessonStatus() : base()
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
    <Hash>cdcb7d4418f2812d7808cf190bb082e4</Hash>
</Codenesium>*/