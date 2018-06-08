using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOPassword: AbstractBusinessObject
        {
                public BOPassword() : base()
                {
                }

                public void SetProperties(int businessEntityID,
                                          DateTime modifiedDate,
                                          string passwordHash,
                                          string passwordSalt,
                                          Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.PasswordHash = passwordHash;
                        this.PasswordSalt = passwordSalt;
                        this.Rowguid = rowguid;
                }

                public int BusinessEntityID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string PasswordHash { get; private set; }

                public string PasswordSalt { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e437b4cb32d89bd840833c4784666029</Hash>
</Codenesium>*/