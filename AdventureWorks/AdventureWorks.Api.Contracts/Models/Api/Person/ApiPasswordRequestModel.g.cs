using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPasswordRequestModel : AbstractApiRequestModel
        {
                public ApiPasswordRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string passwordHash,
                        string passwordSalt,
                        Guid rowguid)
                {
                        this.ModifiedDate = modifiedDate;
                        this.PasswordHash = passwordHash;
                        this.PasswordSalt = passwordSalt;
                        this.Rowguid = rowguid;
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private string passwordHash;

                [Required]
                public string PasswordHash
                {
                        get
                        {
                                return this.passwordHash;
                        }

                        set
                        {
                                this.passwordHash = value;
                        }
                }

                private string passwordSalt;

                [Required]
                public string PasswordSalt
                {
                        get
                        {
                                return this.passwordSalt;
                        }

                        set
                        {
                                this.passwordSalt = value;
                        }
                }

                private Guid rowguid;

                [Required]
                public Guid Rowguid
                {
                        get
                        {
                                return this.rowguid;
                        }

                        set
                        {
                                this.rowguid = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>5cb3f305950f042e10d951eb86185ed7</Hash>
</Codenesium>*/