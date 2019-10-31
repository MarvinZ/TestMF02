using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_backend;
using quiz_backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace quiz_backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Quizzes")]
    public class QuizzesController : Controller
    {
        private readonly QuizContext _context;

        public QuizzesController(QuizContext context)
        {
            _context = context;
        }

        // GET: api/Quizzes
        [Authorize]
        [HttpGet]
        public IEnumerable<Quiz> GetQuiz()
        {
            var userId = HttpContext.User.Claims.First().Value;

            return _context.Quiz.Where(q => q.OwnerId == userId);
        }

        [HttpGet("all")]
        public IEnumerable<Quiz> GetAllQuizzes()
        {
            return _context.Quiz;
        }

        [HttpGet("GetAllFeeds")]
        public IEnumerable<Feed> GetAllFeeds()
        {
            return _context.Feed;
        }

        [HttpPost("GetMyFeeds")]
        public IEnumerable<Feed> GetMyFeeds([FromBody] SimpleUser simpleUSer)
        {
            var myFeeds = _context.UserFeed.Where(e => e.UserId == simpleUSer.UserId).ToList();
            var allFeeds = _context.Feed.ToList();
            foreach (var feed in allFeeds)
            {
                if(myFeeds.Any(e=>e.FeedId == feed.Id))
                {
                    feed.isSubscribed = true;
                }
            }
            return allFeeds;
        }


        [HttpPost("SubscribeUnsubscribe")]
        public bool SubscribeUnsubscribe([FromBody] UserFeed uf)
        {
            var relationship = _context.UserFeed.SingleOrDefault(m => m.UserId == uf.UserId && m.FeedId == uf.FeedId);
            if (relationship == null)
            {
                _context.UserFeed.Add(new UserFeed { FeedId = uf.FeedId, UserId = uf.UserId });
            }
            else
            {
                _context.UserFeed.Remove(relationship);

            }
            _context.SaveChanges();
            return true;
        }


        // GET: api/Quizzes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quiz = await _context.Quiz.SingleOrDefaultAsync(m => m.ID == id);

            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

        // PUT: api/Quizzes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiz([FromRoute] int id, [FromBody] Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quiz.ID)
            {
                return BadRequest();
            }

            _context.Entry(quiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
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

        // POST: api/Quizzes
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostQuiz([FromBody] Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = HttpContext.User.Claims.First().Value;

            quiz.OwnerId = userId;

            _context.Quiz.Add(quiz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuiz", new { id = quiz.ID }, quiz);
        }

        // DELETE: api/Quizzes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quiz = await _context.Quiz.SingleOrDefaultAsync(m => m.ID == id);
            if (quiz == null)
            {
                return NotFound();
            }

            _context.Quiz.Remove(quiz);
            await _context.SaveChangesAsync();

            return Ok(quiz);
        }

        private bool QuizExists(int id)
        {
            return _context.Quiz.Any(e => e.ID == id);
        }
    }
}