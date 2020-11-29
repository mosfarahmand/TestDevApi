using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevTestApi.DAL.DTOs;
using DevTestApi.DAL.Models;
using DevTestApi.Helpers;

namespace DevTestApi.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(string id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        void Update(AppUser user);
        Task<MemberDto> GetMemberAsync(string username);
        Task<List<MemberDto>> GetMembersAsync();
        Task<PagedList<MemberDto>> GetMembersPaginationAsync(UserParams userParams);
    }
}