using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.API.W.Models;

namespace Solution.API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupUsersController : ControllerBase
    {
        private readonly SocialGoalContext _context;

        public GroupUsersController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: api/GroupUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupUsers>>> GetGroupUsers()
        {
            return await _context.GroupUsers.ToListAsync();
        }

        // GET: api/GroupUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupUsers>> GetGroupUsers(int id)
        {
            var groupUsers = await _context.GroupUsers.FindAsync(id);

            if (groupUsers == null)
            {
                return NotFound();
            }

            return groupUsers;
        }

        // PUT: api/GroupUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupUsers(int id, GroupUsers groupUsers)
        {
            if (id != groupUsers.GroupUserId)
            {
                return BadRequest();
            }

            _context.Entry(groupUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupUsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GroupUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GroupUsers>> PostGroupUsers(GroupUsers groupUsers)
        {
            _context.GroupUsers.Add(groupUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupUsers", new { id = groupUsers.GroupUserId }, groupUsers);
        }

        // DELETE: api/GroupUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupUsers>> DeleteGroupUsers(int id)
        {
            var groupUsers = await _context.GroupUsers.FindAsync(id);
            if (groupUsers == null)
            {
                return NotFound();
            }

            _context.GroupUsers.Remove(groupUsers);
            await _context.SaveChangesAsync();

            return groupUsers;
        }

        private bool GroupUsersExists(int id)
        {
            return _context.GroupUsers.Any(e => e.GroupUserId == id);
        }
    }
}
