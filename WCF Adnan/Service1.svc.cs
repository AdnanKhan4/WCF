using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Adnan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        MFAEntities db = new MFAEntities();
        public bool delete(int id)
        {
            try
            {
                Student obj = db.Students.FirstOrDefault(i => i.StudentId == id);
                db.Students.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
                
            }
        }

        public List<Student> getStudent()
        {
            return db.Students.ToList();
        }

        public bool insert(string name, string phone, string email, string password)
        {
                try
                {
                    Student obj = new Student
                    {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Password = password
                    };
                db.Students.Add(obj);
                db.SaveChanges();
                return true;
                }
                catch
                {
                    return false;

                }
        }

        public bool update(int id, string name, string phone, string email, string password)
        {
            try
            {
                Student obj = new Student
                {
                    StudentId = id,
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Password = password
                };
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
               
            }
        }
    }
}
