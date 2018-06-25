using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOStore : AbstractBusinessObject
        {
                public AbstractBOStore()
                        : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
                                                  string demographics,
                                                  DateTime modifiedDate,
                                                  string name,
                                                  Guid rowguid,
                                                  int? salesPersonID)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.Demographics = demographics;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.SalesPersonID = salesPersonID;
                }

                public int BusinessEntityID { get; private set; }

                public string Demographics { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public Guid Rowguid { get; private set; }

                public int? SalesPersonID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0e6a88465191ff55f5c4cc6fee161d3e</Hash>
</Codenesium>*/