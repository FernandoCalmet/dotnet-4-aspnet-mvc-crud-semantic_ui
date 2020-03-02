using System;
using System.Linq;
using System.Web.Security;

namespace CSharp_ASPNET_MVC_CRUD_SQL.Models
{
    public class UserRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string pRole_name)
        {
            using (ExampleDBEntities _Context = new ExampleDBEntities())
            {
                var userRoles = (from userMapping in _Context.Users
                                 join roleMapping in _Context.Roles
                                 on userMapping.id_role equals roleMapping.id_role
                                 join permissionMapping in _Context.Permissions
                                 on roleMapping.id_role equals permissionMapping.id_role
                                 join OperationMapping in _Context.Operations
                                 on permissionMapping.id_operation equals OperationMapping.id_operation
                                 where permissionMapping.id_role == userMapping.id_role
                                 && roleMapping.name == pRole_name
                                 select roleMapping.name).ToArray();
                return userRoles;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}