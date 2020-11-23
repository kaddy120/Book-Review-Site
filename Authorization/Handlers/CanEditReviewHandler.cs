using Books.Authorization.Requirements;
using Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Authorization.Handlers
{
    public class CanEditReviewHandler : AuthorizationHandler<CanEditReview, Review>
    {
        private readonly UserManager<User> userManager;

        public CanEditReviewHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            CanEditReview requirement,
            Review resource)
        {
            var User = userManager.GetUserAsync(context.User)
                .GetAwaiter()
                .GetResult();

            if(resource.Id == User.Id)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
