using System.Threading.Tasks;
using Abp.Authorization.Users;
using Fzrain.MultiTenancy;

namespace Fzrain.Authorization.Users
{
    /// <summary>
    /// Defines an authorization source to be used by <see cref="AbpUserManager{TTenant,TRole,TUser}.LoginAsync"/> method.
    /// </summary>
    public interface IExternalAuthenticationSource
       
    {
        /// <summary>
        /// Unique name of the authentication source.
        /// This source name is set to <see cref="AbpUser{TTenant,TUser}.AuthenticationSource"/>
        /// if the user authenticated by this authentication source
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Used to try authenticate a user by this source.
        /// </summary>
        /// <param name="userNameOrEmailAddress">User name or email address</param>
        /// <param name="plainPassword">Plain password of the user</param>
        /// <param name="tenant">Tenant of the user or null (if user is a host user)</param>
        /// <returns>True, indicates that this used has authenticated by this source</returns>
        Task<bool> TryAuthenticateAsync(string userNameOrEmailAddress, string plainPassword, Tenant tenant);

        /// <summary>
        /// This method is a user authenticated by this source which does not exists yet.
        /// So, source should create the User and fill properties.
        /// </summary>
        /// <param name="userNameOrEmailAddress">User name or email address</param>
        /// <param name="tenant">Tenant of the user or null (if user is a host user)</param>
        /// <returns>Newly created user</returns>
        Task<User> CreateUserAsync(string userNameOrEmailAddress, Tenant tenant);

        /// <summary>
        /// This method is called after an existing user is authenticated by this source.
        /// It can be used to update some properties of the user by the source.
        /// </summary>
        /// <param name="user">The user that can be updated</param>
        /// <param name="tenant">Tenant of the user or null (if user is a host user)</param>
        Task UpdateUserAsync(User user, Tenant tenant);
    }
}