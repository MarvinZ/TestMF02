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