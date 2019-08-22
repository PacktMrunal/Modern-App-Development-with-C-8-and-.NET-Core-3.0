using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PlansController : ControllerBase
    {
        private readonly AppDbContext _context;

        private int GetUserId()
        {
            var claims = User.Claims;
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            int result;
            if (Int32.TryParse(userId, out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid user token");
            }
        }

        public PlansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Plans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlans()
        {
            int userId = GetUserId();
            return await _context.Plans.Where(p => p.UserId == userId).ToListAsync();
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetPlan(int id)
        {
            var userId = GetUserId();
            var plan = await _context.Plans.FirstOrDefaultAsync(p => p.UserId == userId && p.Id == id);

            if (plan == null)
            {
                return NotFound();
            }

            return plan;
        }

        // PUT: api/Plans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan(int id, Plan plan)
        {
            if (id != plan.Id)
            {
                return BadRequest();
            }
            if (plan.UserId != GetUserId())
            {
                throw new AccessViolationException("Access Denied");
            }

            _context.Entry(plan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanExists(id))
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

        // POST: api/Plans
        [HttpPost]
        public async Task<ActionResult<Plan>> PostPlan(Plan plan)
        {
            var userId = GetUserId();
            plan.UserId = userId;
            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlan", new { id = plan.Id }, plan);
        }

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Plan>> DeletePlan(int id)
        {
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }
            if(plan.UserId != GetUserId())
            {
                throw new AccessViolationException("Access Denied");
            }

            _context.Plans.Remove(plan);
            await _context.SaveChangesAsync();

            return plan;
        }

        private bool PlanExists(int id)
        {
            return _context.Plans.Any(e => e.Id == id);
        }
    }
}
