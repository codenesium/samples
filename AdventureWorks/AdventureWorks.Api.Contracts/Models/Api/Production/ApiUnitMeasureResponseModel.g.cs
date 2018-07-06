using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiUnitMeasureResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string unitMeasureCode,
                        DateTime modifiedDate,
                        string name)
                {
                        this.UnitMeasureCode = unitMeasureCode;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public string UnitMeasureCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>122feaf9b2a9b7bdfe4cc8789a5b9ea3</Hash>
</Codenesium>*/