using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FormationVueDotnet.Models;
using FormationVueDotnet.Context;
using FormationVueDotnet.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FormationVueDotnet.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context) => this._context = context;

        #region GET

        [HttpGet, Route("getById")]
        public PersonViewModel GetById(int personId)
        {
            Person p = _context.Persons.Include(pers => pers.ContactInfoPerso).SingleOrDefault(pers => pers.Id == personId);

            return this.ToPersonViewModel(p);
        }
        
        [HttpGet, Route("getByName")]
        public List<PersonViewModel> GetByName(string query)
        {
            List<PersonViewModel> lpvm = null;
            
            if(!string.IsNullOrEmpty(query))
            {
                string[] splitQuery = query.Split(' ');
                List<Person> lp = null;
                
                if(splitQuery.Length == 1)
                {
                    if(!string.IsNullOrEmpty(splitQuery[0]))
                    {
                        lp = _context.Persons.Where(p => p.Firstname.ToLowerInvariant().Contains(splitQuery[0].ToLowerInvariant()) || p.Lastname.Contains(splitQuery[0].ToLowerInvariant())).ToList();
                        lpvm = ToListPersonViewModel(lp);
                    }
                }
                else
                {
                    lp = _context.Persons.Where(p => (p.Firstname.ToLowerInvariant().Contains(splitQuery[0].ToLowerInvariant()) || p.Lastname.ToLowerInvariant().Contains(splitQuery[0].ToLowerInvariant())) && 
                                                    (p.Firstname.ToLowerInvariant().Contains(splitQuery[1].ToLowerInvariant()) || p.Lastname.ToLowerInvariant().Contains(splitQuery[1].ToLowerInvariant()))).ToList();
                    lpvm = ToListPersonViewModel(lp);

                }
            }

            return lpvm;
        }

        [HttpGet, Route("getBySkill")]
        public List<PersonViewModel> GetBySkill(string skill)
        {
            List<Person> lp = _context.Persons.Where(p => p.Skills.Any(s => s.Name.ToLowerInvariant().Contains(skill.ToLowerInvariant()))).ToList();

            return ToListPersonViewModel(lp);
        }

        
        [HttpGet, Route("getRandom")]
        public PersonViewModel GetRandom()
        {
            Random rand = new Random();
            Person p = null;
            
            int countRows = _context.Persons.ToList().Count;

            while(p == null)
            {
                p = _context.Persons.Include(pers => pers.ContactInfoPerso).FirstOrDefault(pers => pers.Id == rand.Next(countRows + 1));
            }

            return this.ToPersonViewModel(p);
        }

        [HttpGet, Route("getAll")]
        public List<PersonViewModel> GetAll()
        {
            List<Person> lp = _context.Persons.Include(pers => pers.ContactInfoPerso).ToList();
            
            return this.ToListPersonViewModel(lp);
        }

        #endregion

        #region POST
        
        [HttpPost, Route("create")]
        public void Create(PersonFormViewModel vm)
        {
            try
            {
                Person p = new Person(); 

                p.Firstname = vm.Firstname;
                p.Lastname = vm.LastName;
                
                // The datetime cannot be null
                // For the example we put a default datetime 
                DateTime date = DateTime.Now;
                p.BirthDate = date;
                p.EntryDate = date;

                // NumberOfChild cannot be null 
                p.NumberOfChild = 0;

                ContactInfoPerso cip = new ContactInfoPerso();
                cip.Mail = vm.Email;
                cip.MobilePhone = vm.Phone;

                p.ContactInfoPerso = cip;

                _context.Persons.Add(p);
                _context.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        #endregion

        #region PUT

        [HttpPut, Route("update")]
        public void Update(PersonFormViewModel vm)
        {
            try
            {
                if(vm.Id.HasValue)
                {
                    Person p = _context.Persons.Include(pers => pers.ContactInfoPerso).SingleOrDefault(pers => pers.Id == vm.Id.Value);
                    
                    if(p != null)
                    {
                        p.Firstname = vm.Firstname;
                        p.Lastname = vm.LastName;
                        p.ContactInfoPerso.Mail = vm.Email;
                        p.ContactInfoPerso.MobilePhone = vm.Phone;

                        _context.SaveChanges();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        #endregion

        #region DELETE
        
        [HttpDelete, Route("delete")]
        public void Delete(int personId)
        {
            try
            {
                Person p = _context.Persons.Include(pers => pers.ContactInfoPerso).SingleOrDefault(pers => pers.Id == personId);
                
                if(p != null)
                {
                    _context.Persons.Remove(p);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

    #endregion

    #region private methods

    private PersonViewModel ToPersonViewModel(Person p) => new PersonViewModel
    {
        Id = p.Id,
        Firstname = p.Firstname,
        Lastname = p.Lastname,
        Entity = p.Entity,
        Email = p.ContactInfoPerso.Mail,
        Phone = p.ContactInfoPerso.MobilePhone,
        Manager = p.Manager,
        Photo = p.Photo
    };

    private List<PersonViewModel> ToListPersonViewModel(List<Person> lp)
        {
            List<PersonViewModel> res = new List<PersonViewModel>();

            foreach(Person p in lp)
            {
                res.Add(new PersonViewModel {
                    Id = p.Id,
                    Firstname = p.Firstname ,
                    Lastname = p.Lastname,
                    Entity = p.Entity,
                    Email = p.ContactInfoPerso.Mail,
                    Phone = p.ContactInfoPerso.MobilePhone,
                    Manager = p.Manager,
                    Photo = p.Photo
                });
            }

            return res;
        }
        
        #endregion 
    }
}