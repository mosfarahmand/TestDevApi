using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DevTestApi.Contracts;
using DevTestApi.DAL.DTOs;
using DevTestApi.Extensions;
using DevTestApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevTestApi.Controllers
{
    /// <summary>
    /// User API
    /// </summary>
    [Authorize]
    public class UserController : BaseApiController
    {

        #region Private members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region Get list of users

        /// <summary>
        /// List of users
        /// </summary>
        /// <returns>Return list of users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _unitOfWork.UserRepository.GetMembersAsync();
            return Ok(users);
        }

        #endregion

        #region get user by username

        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="username">Example: john</param>
        /// <returns>User info</returns>
        [HttpGet("{username}", Name = "GetUser")]
        public async Task<ActionResult<MemberDto>> GetUserByUsername(string username)
        {
            return await _unitOfWork.UserRepository.GetMemberAsync(username);
        }

        #endregion

        #region Update user

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="memberUpdate"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdate)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(User.GetUsername());
            _mapper.Map(memberUpdate, user);
            _unitOfWork.UserRepository.Update(user);
            if (await _unitOfWork.Complete()) return NoContent();
            return BadRequest("Failed to update user");
        }

        #endregion

        #region Get users with pagination

        /// <summary>
        /// Get list of user with pagination
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns>user lists</returns>
        [HttpGet("get-users")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetPaginatedUsers([FromQuery] UserParams userParams)
        {
            var users = await _unitOfWork.UserRepository.GetMembersPaginationAsync(userParams);
            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPage);
            return Ok(users);
        }

        #endregion
    }
}