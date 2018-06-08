using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOLessonStatus: AbstractBusinessObject
        {
                public BOLessonStatus() : base()
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
    <Hash>eba322eea8f7cadd636f385f2a7b90d8</Hash>
</Codenesium>*/