using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_backend.Models
{
    public class SampleData
    {
        private UserDbContext _context;
        private QuizContext _context2;


        public SampleData(UserDbContext context, QuizContext context2)
        {
            _context = context;
            _context2 = context2;
        }          


        public async void SeedAdminUser()
        {
            var user = new IdentityUser
            {
                UserName = "Email@email.com",
                NormalizedUserName = "Email@email.com",
                Email = "Email@email.com",
                NormalizedEmail = "email@email.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()

            };

            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "admin"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
            }

            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<IdentityUser>();
                var hashed = password.HashPassword(user, "hola");
                user.PasswordHash = hashed;
                var userStore2 = new UserStore<IdentityUser>(_context);
                await userStore2.CreateAsync(user);
                await userStore2.AddToRoleAsync(user, "admin");
            }

            await _context.SaveChangesAsync();


            var userStore = new UserStore<IdentityUser>(_context);
            var password2 = new PasswordHasher<IdentityUser>();
            var hashed2 = password2.HashPassword(user, "hola");

            IdentityUser user0, user1;
            if (_context.Users.Any(u => u.UserName == "nemo@mail.com"))
                user0 = _context.Users.First(u => u.UserName == "nemo@mail.com");
            else
            {
                user0 = new IdentityUser { UserName = "nemo@mail.com", Email = "nemo@mail.com", PasswordHash = hashed2 };
                var result = userStore.CreateAsync(user0).Result;
            }
            if (_context.Users.Any(u => u.UserName == "teresa@mail.com"))
                user1 = _context.Users.First(u => u.UserName == "teresa@mail.com");
            else
            {
                user1 = new IdentityUser { UserName = "teresa@mail.com", Email = "teresa@mail.com", PasswordHash = hashed2 };
                var result = userStore.CreateAsync(user1).Result;
            }
                                 

        }

        public async void SeedFeeds()
        {
            var tempList = new List<Feed>();

            var feed1 = new Feed
            {
                Title = "Top Headlines",
                url = "https://www.espn.com/espn/rss/news"
            };
            tempList.Add(feed1);

            var feed2 = new Feed
            {
                Title = "NFL",
                url = "https://www.espn.com/espn/rss/nfl/news"
            };
            tempList.Add(feed2);


            var feed3 = new Feed
            {
                Title = "NBA",
                url = "https://www.espn.com/espn/rss/nba/news"
            };
            tempList.Add(feed3);


            var feed4 = new Feed
            {
                Title = "MLB",
                url = "https://www.espn.com/espn/rss/mlb/news"
            };
            tempList.Add(feed4);


            var feed5 = new Feed
            {
                Title = "NHL",
                url = "https://www.espn.com/espn/rss/nhl/news"
            };
            tempList.Add(feed5);


            var feed6 = new Feed
            {
                Title = "Motors",
                url = "https://www.espn.com/espn/rss/rpm/news"
            };
            tempList.Add(feed6);


            var feed7 = new Feed
            {
                Title = "Soccer",
                url = "https://www.espn.com/espn/rss/soccer/news"
            };
            tempList.Add(feed7);


            var feed8 = new Feed
            {
                Title = "U",
                url = "https://www.espn.com/espn/rss/espnu/news"
            };
            tempList.Add(feed8);


            var feed9 = new Feed
            {
                Title = "NCAAB",
                url = "https://www.espn.com/espn/rss/ncb/news"
            };
            tempList.Add(feed9);


            var feed10 = new Feed
            {
                Title = "NCAAF",
                url = "https://www.espn.com/espn/rss/ncf/news"
            };
            tempList.Add(feed10);

            var feed11 = new Feed
            {
                Title = "Action",
                url = "https://www.espn.com/espn/rss/action/news"
            };
            tempList.Add(feed10);

            var feed12 = new Feed
            {
                Title = "Poker",
                url = "https://www.espn.com/espn/rss/poker/master"
            };
            tempList.Add(feed10);



            foreach (var fd in tempList)
            {
                if (!_context2.Feed.Any(u => u.Title == fd.Title))
                {
                    _context2.Feed.Add(fd);
                }

            }
            await _context2.SaveChangesAsync();

        }
        public async void SeedQuizes()
        {
            var userId = _context.Users.Where(e => e.Email == "Email@email.com").FirstOrDefault().Id;

            var quiz = new Quiz
            {
                OwnerId = userId,
                Title = "I am a happy quiz"
            };

            var quiz2 = new Quiz
            {
                OwnerId = userId,
                Title = "I am a sad quiz"
            };
              
            _context2.Quiz.Add(quiz);
            _context2.Quiz.Add(quiz2);

            await _context2.SaveChangesAsync();



            var question = new Question
            {
                QuizId = 1,
                Answer1 = "yes",
                Answer2 = "No",
                Answer3 = "OK",
                CorrectAnswer = "Manu y Gali",
                Text = "pregunta 1"
            };

            var question2 = new Question
            {
                QuizId = 1,
                Answer1 = "yes",
                Answer2 = "No",
                Answer3 = "OK",
                CorrectAnswer = "Manu y Gali",
                Text = "pregunta 1"
            };



            var question3 = new Question
            {
                QuizId = 2,
                Answer1 = "yes",
                Answer2 = "No",
                Answer3 = "OK",
                CorrectAnswer = "Manu y Gali",
                Text = "pregunta 1"
            };

            var question4 = new Question
            {
                QuizId = 2,
                Answer1 = "yes",
                Answer2 = "No",
                Answer3 = "OK",
                CorrectAnswer = "Manu y Gali",
                Text = "pregunta 1"
            };

            _context2.Questions.Add(question);
            _context2.Questions.Add(question2);
            _context2.Questions.Add(question3);
            _context2.Questions.Add(question4);

            await _context2.SaveChangesAsync();

        }
    }
}