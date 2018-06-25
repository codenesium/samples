using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOSalesTerritoryHistory : AbstractBusinessObject
        {
                public AbstractBOSalesTerritoryHistory()
                        : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
                                                  DateTime? endDate,
                                                  DateTime modifiedDate,
                                                  Guid rowguid,
                                                  DateTime startDate,
                                                  int territoryID)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                        this.StartDate = startDate;
                        this.TerritoryID = territoryID;
                }

                public int BusinessEntityID { get; private set; }

                public DateTime? EndDate { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Guid Rowguid { get; private set; }

                public DateTime StartDate { get; private set; }

                public int TerritoryID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>99aa9f9ac04794d18422dcd0a8fde926</Hash>
</Codenesium>*/