using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOLibraryVariableSet : AbstractBusinessObject
        {
                public AbstractBOLibraryVariableSet()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  string contentType,
                                                  string jSON,
                                                  string name,
                                                  string variableSetId)
                {
                        this.ContentType = contentType;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.VariableSetId = variableSetId;
                }

                public string ContentType { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string VariableSetId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2f8cf62c2002399132fb220907768540</Hash>
</Codenesium>*/