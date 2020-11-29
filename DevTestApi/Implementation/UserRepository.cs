using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevTestApi.Contracts;
using DevTestApi.DAL;
using DevTestApi.DAL.DTOs;
using DevTestApi.DAL.Models;
using DevTestApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DevTestApi.Implementation
{
    public class UserRepository : IUserRepository
    {
        #region Private Members

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Get all user async

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        #endregion

        #region Get user by id async

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        #endregion

        #region Get user by username async

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
        }

        #endregion

        #region Update user

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        #endregion
 
        #region Get member async

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.Users.Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        #endregion
        
        #region Get users list map to members

        public async Task<List<MemberDto>> GetMembersAsync()
        {
            return await _context.Users
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .AsNoTracking().ToListAsync();
        }

        #endregion

        #region Get users list map to member with paginations

        public async Task<PagedList<MemberDto>> GetMembersPaginationAsync(UserParams userParams)
        {
            var query = _context.Users
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .AsNoTracking();
            return await PagedList<MemberDto>.CreateAsync(query, userParams.PageNumber, userParams.PageSize);
        }

        #endregion
        
    }
}