using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOCulture: AbstractBusinessObject
        {
                public BOCulture() : base()
                {
                }

                public void SetProperties(string cultureID,
                                          DateTime modifiedDate,
                                          string name)
                {
                        this.CultureID = cultureID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public string CultureID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ae2ed078b894ad442acdf43fd5ea995e</Hash>
</Codenesium>*/