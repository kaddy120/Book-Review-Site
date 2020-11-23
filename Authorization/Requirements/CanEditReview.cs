using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Authorization.Requirements
{
    public class CanEditReview: IAuthorizationRequirement
    {}
}
