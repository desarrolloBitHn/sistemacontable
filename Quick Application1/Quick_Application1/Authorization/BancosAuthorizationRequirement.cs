using Microsoft.AspNetCore.Authorization;
using System;
using DAL.Core;
using System.Security.Claims;
using Quick_Application1.Helpers;
using Quick_Application1.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quick_Application1.Authorization
{
    public class BancosAuthorizationRequirement : IAuthorizationRequirement
    {
        public BancosAuthorizationRequirement(string operationName)
        {
            this.OperationName = operationName;
        }


        public string OperationName { get; private set; }
    }

    public class ViewBancosAuthorizationHandler : AuthorizationHandler<BancosAuthorizationRequirement, string>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BancosAuthorizationRequirement requirement, string targetUserId)
        {
            try
            {
                if (context.User == null || requirement.OperationName != BancoManagementOperations.ReadOperationName)
                    return Task.CompletedTask;

                if (context.User.HasClaim(CustomClaimTypes.Permission, ApplicationPermissions.ViewBanks) || GetIsSameUser(context.User, targetUserId))
                    context.Succeed(requirement);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            return Task.CompletedTask;
        }

        private bool GetIsSameUser(ClaimsPrincipal user, string targetUserId)
        {
            if (string.IsNullOrWhiteSpace(targetUserId))
                return false;

            return Utilities.GetUserId(user) == targetUserId;
        }
    }

    public class ManageBancosAuthorizationHandler : AuthorizationHandler<BancosAuthorizationRequirement, string>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BancosAuthorizationRequirement requirement, string targetUserId)
        {

            if (context.User == null ||
                (requirement.OperationName != BancoManagementOperations.CreateOperationName &&
                 requirement.OperationName != BancoManagementOperations.UpdateOperationName &&
                 requirement.OperationName != BancoManagementOperations.DeleteOperationName))
                return Task.CompletedTask;


            if (context.User.HasClaim(CustomClaimTypes.Permission, ApplicationPermissions.ViewBanks) || GetIsSameUser(context.User, targetUserId))
                context.Succeed(requirement);


            return Task.CompletedTask;
        }

        private bool GetIsSameUser(ClaimsPrincipal user, string targetUserId)
        {
            if (string.IsNullOrWhiteSpace(targetUserId))
                return false;

            return Utilities.GetUserId(user) == targetUserId;
        }
    }
}
